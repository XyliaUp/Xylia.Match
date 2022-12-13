using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using CUE4Parse.UE4.Assets.Exports.Texture;

using Xylia.Preview.Data.Package.Pak;

namespace Xylia.Match.Windows.Panel
{
	public partial class PakExtract : UserControl
	{
		#region 构造
		public PakExtract()
		{
			InitializeComponent();

			this.Path_OutDir.Text = Xylia.Configure.Ini.ReadValue(this.GetType(), nameof(this.Path_OutDir));
		}
		#endregion


		#region 方法
		private void Btn_Output_BtnClick(object sender, EventArgs e)
		{
			var Selector = this.Selector.TextValue;
			bool KeepTree = Selector.Contains('/');

			new Thread(t =>
			{
				this.Btn_Output.Visible = false;

				PakData PakData = new();
				PakData.Initialize(null);

				var _gamefiles = PakData._provider.GameFiles;
				if (_gamefiles != null)
				{
					var tempPath = KeepTree ? Selector : $"GameUI/Resource/{Selector}/";

					foreach (var gamefile in _gamefiles.Where(o => o.Extension == "uasset" && o.Path.Contains(tempPath)))
					{
						string dir = KeepTree ? Path.GetDirectoryName(gamefile.Path) : Path.GetFileName(Path.GetDirectoryName(gamefile.Path));
						dir = this.Path_OutDir.Text + "\\" + dir + "\\";

						string path = dir + Path.GetFileNameWithoutExtension(gamefile.Path);
						if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

						var exports = PakData._provider.LoadObjectExports(gamefile.Path);
						if (exports is null || !exports.Any()) continue;

						var export = exports.First();
						if (export is UTexture2D texture) texture.GetImage().Save(path + ".png");
					}
				}

				PakData._provider.Dispose();
				PakData = null;

				GC.Collect();
				this.Btn_Output.Visible = true;

			}).Start();
		}
		#endregion






		private void PakExtract_Load(object sender, EventArgs e)
		{

		}

		private void ucBtnFillet1_BtnClick(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new()
			{

			};

			if (dialog.ShowDialog() == DialogResult.OK)
				Path_OutDir.Text = dialog.SelectedPath;
		}

		private void Path_OutDir_TextChanged(object sender, EventArgs e)
		{
			Xylia.Configure.Ini.WriteValue(this.GetType(), nameof(this.Path_OutDir), this.Path_OutDir.Text);
		}
	}
}