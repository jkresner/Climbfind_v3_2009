using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using ClimbFind.Model.DataAccess;
using ClimbFind.Model.Objects;
using System.IO;

namespace IdentityStuff.Views.Admin
{
	public partial class DeleteCachedDiskImages : ViewPage
	{
		public List<string> Directories { get; set; }
		public List<string> Files { get; set; }

		protected void Page_Load(Object o, EventArgs e)
		{
			Directories = Directory.GetDirectories(ClimbFind.Controller.CFSettings.OSClimberProfilePicImgDir).ToList();

			Files = new List<string>();

			foreach (var dir in Directories)
			{
				foreach (var file in Directory.GetFiles(dir))
				{
					if (Path.GetFileName(file).Contains("CPinMB"))
					{
						File.Delete(file);
						//Files.Add(file);
					}
					else if (Path.GetFileName(file).Contains("CPinPF"))
					{
						//Files.Add(file);
						File.Delete(file);
					}
				}
				
			}
			
			
			
			//ClimbFind.Controller.CFSettings.OSClimberProfilePicImgDir
//			ClimbFind.Controller.CFSettings.OSClimberProfilePicImgDir

		}
	}
}

