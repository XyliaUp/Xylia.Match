using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using Xylia.Configure;
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

			new Thread(t =>
			{
				this.Btn_Output.Visible = false;

				PakData PakData = new();
				PakData.Initialize(null);


				var tempPath = Selector.Contains('/') ? Selector : $"GameUI/Resource/{Selector}/";
				var gameFiles = PakData._provider.GameFiles?.Where(o => o.Extension == "uasset" && o.Path.Contains(tempPath));
				if (gameFiles != null)
				{
					foreach (var gamefile in gameFiles)
					{
						string dir = true ? Path.GetDirectoryName(gamefile.Path) : Path.GetFileName(Path.GetDirectoryName(gamefile.Path));
						dir = this.Path_OutDir.Text + "\\" + dir + "\\";

						string path = dir + Path.GetFileNameWithoutExtension(gamefile.Path);
						if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

						var exports = PakData._provider.LoadObjectExports(gamefile.Path);
						if (exports is null || !exports.Any()) continue;


						var export = exports.First();
						export.GetImage()?.Save(path + ".png");
					}
				}

				gameFiles = null;

				PakData._provider.Dispose();
				PakData = null;

				GC.Collect();
				this.Btn_Output.Visible = true;

			}).Start();
		}
		

		private void ucBtnFillet1_BtnClick(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new()
			{

			};

			if (dialog.ShowDialog() == DialogResult.OK)
				Path_OutDir.Text = dialog.SelectedPath;
		}

		private void Path_OutDir_TextChanged(object sender, EventArgs e) => Ini.WriteValue(this.GetType(), nameof(this.Path_OutDir), this.Path_OutDir.Text);
		#endregion
	}
}