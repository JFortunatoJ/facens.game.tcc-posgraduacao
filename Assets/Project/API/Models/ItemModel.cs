namespace Project.API.Models
{
    [System.Serializable]
    public class ItemModel
    {
        public string id;
        public string itemId;
        public int amount;

        public ItemModel(string id, string itemId, int amount)
        {
            this.id = id;
            this.itemId = itemId;
            this.amount = amount;
        }
    }
}