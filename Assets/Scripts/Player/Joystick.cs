namespace Assets.Scripts.Player
{
    public class Joystick
    {

        public readonly string Horizontal;
        public readonly string Vertical;
        public readonly string Dash;
        public readonly string Action;

        public Joystick(int playerNumber)
        {
            Horizontal = "Horizontal_P" + playerNumber;
            Vertical = "Vertical_P" + playerNumber;
            Dash = "Dash_P" + playerNumber;
            Action = "Action_P" + playerNumber;
        }
    }
}
