using System.Windows.Forms;

using Xylia.Match.Windows.Panel;

namespace Xylia.Match.Windows
{
	/// <summary>
	/// 界面组
	/// </summary>
	public class SubGroup
	{
		Control m_Prop = null;
		public Control matchProp
		{
			get
			{
				if (m_Prop == null || m_Prop.IsDisposed) m_Prop = new Panel.MatchProp() { Dock = DockStyle.Top };
				return m_Prop;
			}
		}

		Control m_ICON = null;
		public Control matchICON
		{
			get
			{
				if (m_ICON == null || m_ICON.IsDisposed) m_ICON = new Panel.IconOperator() { Dock = DockStyle.Top };
				return m_ICON;
			}
		}

		Control m_Local = null;
		public Control matchLocal
		{
			get
			{
				if (m_Local == null || m_Local.IsDisposed) m_Local = new Panel.MatchLocal() { Dock = DockStyle.Top };
				return m_Local;
			}
		}

		Control m_Quest = null;
		public Control matchQuest
		{
			get
			{
				if (m_Quest == null || m_Quest.IsDisposed) m_Quest = new QuestMatch() { Dock = DockStyle.Fill };
				return m_Quest;
			}
		}


		Control m_modify_local = null;
		public Control modifyLocal
		{
			get
			{
				if (m_modify_local is null || m_modify_local.IsDisposed) m_modify_local = new Panel.ModifyLocal() { /*Dock = DockStyle.Fill*/ };
				return m_modify_local;
			}
		}


		Xylia.Dev.GetUrl.Form1 m_YouDao { get; set; } = null;
		public Xylia.Dev.GetUrl.Form1 Youdao
		{
			get
			{
				if (m_YouDao == null || m_YouDao.IsDisposed) m_YouDao = new Xylia.Dev.GetUrl.Form1() { Dock = DockStyle.Top };

				return m_YouDao;
			}
		}



		Control _PakExtract = null;
		public Control PakExtract
		{
			get
			{
				if (_PakExtract is null || _PakExtract.IsDisposed) _PakExtract = new PakExtract();
				return _PakExtract;
			}
		}

	}
}