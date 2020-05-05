using System.Windows.Input;

namespace BusinessUI.Models
{
    public sealed class CallFunction
    {
        public CallFunction(string image, string text, ICommand command)
        {
            this.Image = image;
            this.Text = text;
            this.Command = command;
        }

        public string Image { get; }
        public string Text { get; }
        public ICommand Command { get; }
    }
}
