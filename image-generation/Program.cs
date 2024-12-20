using System.Drawing;

#pragma warning disable CA1416

var bitmap = new Bitmap(100, 100);

using (var graphics = Graphics.FromImage(bitmap))
{
	graphics.Clear(Color.White);

	var pen = new Pen(Color.Black);
	graphics.DrawRectangle(pen, 40, 40, 10, 10);
}

bitmap.Save("image.bmp");