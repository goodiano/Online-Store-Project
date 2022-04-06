using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;
using TemplateProjectOne.Domain.Entities.Carts;

namespace TemplateProjectOne.Application.Services.Carts
{
    public interface ICartServices
    {
        RegisterDto AddCart(int productId, Guid browserId);
        RegisterDto RemoveFromCart(int productId, Guid browserId);
        RegisterDto<CartDto> GetCart(Guid browserId, int? UserId);
        RegisterDto Add(int CartItemId);
        RegisterDto LowOff(int CartItemId);
    }

    public class CartService : ICartServices
    {
        private readonly IDataBaseContext _context;
        public CartService(IDataBaseContext context)
        {
            _context = context;
        }

        public RegisterDto Add(int CartItemId)
        {
            var cartItem = _context.CartItem.Find(CartItemId);
            cartItem.Count++;
            _context.SaveChanges();
            return new RegisterDto
            {
                IsSuccess = true
            };
        }

        public RegisterDto AddCart(int productId, Guid browserId)
        {
            var cart = _context.Cart.Where(p => p.BrowserId == browserId && p.Finished == false).FirstOrDefault();
            if (cart == null)
            {
                Cart newCart = new Cart()
                {
                    BrowserId = browserId,
                    Finished = false
                };

                _context.Cart.Add(newCart);
                _context.SaveChanges();
                cart = newCart;
            }

            var product = _context.AddProducts.Find(productId);

            //The reason that the CartItem was used is that we want to find
            //the product and because we do not have access to the browserId
            //on the CartItem, we used the ID in card itself.
            var CartItem = _context.CartItem.Where(p => p.ProductId == productId && p.CartId == cart.Id).FirstOrDefault();


            if (CartItem != null)
            {
                CartItem.Count++;
            }
            else
            {
                CartItem newCartItem = new CartItem()
                {
                    Product = product,
                    Count = 1,
                    Price = product.Price,
                    Cart = cart,
                };

                _context.CartItem.Add(newCartItem);
                _context.SaveChanges();
            }

            return new RegisterDto
            {
                IsSuccess = true,
                Message = $"محصول {product.Name} با موفقیت به سبد خرید افزوده شد"
            };


        }

        public RegisterDto<CartDto> GetCart(Guid browserId, int? UserId)
        {
            try
            {
                var cart = _context.Cart
                .Include(p => p.CartItems)
                .ThenInclude(p => p.Product)
                .ThenInclude(p => p.ProductImages)
                .Where(p => p.BrowserId == browserId && p.Finished == false)
                .OrderByDescending(p => p.Id)
                .FirstOrDefault();


                if (cart == null)
                {
                    return new RegisterDto<CartDto>()
                    {
                        Data = new CartDto()
                        {
                            CartItems = new List<CartItemDto>()
                        },
                        IsSuccess = false,
                    };
                }
                if (UserId != null)
                {
                    var user = _context.Users.Find(UserId);
                    cart.User = user;
                    _context.SaveChanges();
                }


                return new RegisterDto<CartDto>()
                {
                    Data = new CartDto()
                    {
                        CountProduct = cart.CartItems.Count(),
                        SumAmount = cart.CartItems.Sum(p => p.Price * p.Count),
                        CartItems = cart.CartItems.Select(p => new CartItemDto
                        {
                            Count = p.Count,
                            Price = p.Price,
                            Product = p.Product.Name,
                            Id = p.Id,
                            Images = p.Product?.ProductImages?.FirstOrDefault()?.Src ?? ""
                        }).ToList()
                    },
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public RegisterDto LowOff(int CartItemId)
        {

            var cartItem = _context.CartItem.Find(CartItemId);
            if (cartItem.Count <= 1)
            {
                new RegisterDto
                {
                    IsSuccess = false
                };
            }

            cartItem.Count--;
            _context.SaveChanges();
            return new RegisterDto
            {
                IsSuccess = true
            };
        }

        public RegisterDto RemoveFromCart(int productId, Guid browserId)
        {
            var cartItem = _context.CartItem.Where(p => p.Cart.BrowserId == browserId).FirstOrDefault();
            if (cartItem != null)
            {
                if (cartItem.ProductId == productId && cartItem.Product.Count > 1)
                {
                    cartItem.Count--;
                }

                cartItem.IsRemoved = true;
                cartItem.RemoveTime = DateTime.Now;
                _context.SaveChanges();

                return new RegisterDto
                {
                    IsSuccess = true,
                    Message = "محصول از سبد خرید شما حذف شد"
                };
            }

            return new RegisterDto
            {
                IsSuccess = false,
                Message = "محصول مورد نظر یافت نشد"
            };
        }
    }

    public class CartDto
    {
        public int CountProduct { get; set; }
        public decimal SumAmount { get; set; }
        public List<CartItemDto> CartItems { get; set; }
    }
    public class CartItemDto
    {
        public int Id { get; set; }
        public string Images { get; set; }

        public string Product { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
