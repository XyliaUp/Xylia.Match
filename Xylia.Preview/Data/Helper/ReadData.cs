using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Xylia.bns.Modules.DataFormat.BinData;
using Xylia.bns.Modules.DataFormat.BinData.Data.Dat;
using Xylia.bns.Modules.DataFormat.DatData;
using Xylia.bns.Read;
using Xylia.bns.Read.Util;
using Xylia.Extension;

using static Xylia.Extension.String;


namespace Xylia.Preview.Data.Helper
{
	public static class ReadData
	{
		public static string PrevPath = null;

		public static string GetXmlPath(this string GameFolder, bool Is64 = true)
		{
			if (!Directory.Exists(GameFolder)) throw new Exception("未设置游戏目录。");
			if (PrevPath is null)
			{
				var DataPath = new DataPathes(GameFolder);
				var Xmls = DataPath.GetFiles(DatType.xml64, false);
				var Locals = DataPath.GetFiles(DatType.local64, false);

				if (Xmls.Count == 1) PrevPath = Xmls.First().FullName;
				else
				{
					using var select = new DataSelect(new FileCollection(Xmls.FileInfos), new FileCollection(Locals.FileInfos));

					if (select.ShowDialog() == DialogResult.OK) PrevPath = select.XML_Select;
					else throw new ReadException("用户终止操作！");
				}
			}

			return PrevPath;
		}

		public static DataFile LoadFileByGameFolder(string GameFolder, string TargetPath, bool Is64) => LoadFile(GetXmlPath(GameFolder, Is64), TargetPath);

		public static DataFile LoadFile(string XmlPath, string TargetPath) => new BNSDat().ExportFile(XmlPath).Find(datefile => datefile.RelativePath.MyEquals(TargetPath));
	}
}
