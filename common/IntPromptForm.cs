namespace common
{
	class IntPromptForm : PromptForm<int>
	{
		public IntPromptForm(string message)
			: base(message)
		{
		}

		protected override int GetReturnValue()
		{
			return int.Parse(textBox1.Text);
		}

		protected override void SetReturnValue(int val)
		{
			textBox1.Text = val.ToString();
		}
	}
}