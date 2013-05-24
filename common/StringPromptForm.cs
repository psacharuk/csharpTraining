namespace common
{
	class StringPromptForm : PromptForm<string>
	{
		public StringPromptForm(string message)
			: base(message)
		{
		}

		protected override string GetReturnValue()
		{
			return textBox1.Text;
		}

		protected override void SetReturnValue(string val)
		{
			textBox1.Text = val;
		}
	}
}