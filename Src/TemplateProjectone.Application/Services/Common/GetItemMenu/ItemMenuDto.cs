namespace TemplateProjectOne.Application.Services.Common.GetItemMenu
{
    public class ItemMenuDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ItemMenuDto> Child { get; set; }
    }
}
