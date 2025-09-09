namespace ClickerGame.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Player"; 
        public int Clicks { get; set; } = 0;         
        public int ClickPower { get; set; } = 1;     
    }
}
