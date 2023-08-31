/*
 * Date: 30/08/2023
 * Time: 20:55
*/
using System;

namespace Ex05_Datas
{
	/// <summary>
	/// Description of DateConfiguration.
	/// </summary>
	public class DateConfiguration
	{
		public DateConfiguration()
		{
		}
		
		public string FormatDate(int formatChosen, DateTime dateToShow)
		{
			switch(formatChosen)
			{
				default:
					{
						return dateToShow.ToString();
					}
				case 2:
					{
						return dateToShow.ToString("dd-MM-yyyy");
					}
				case 3:
					{
						return dateToShow.ToString("dddd, dd 'de' MMMM 'de' yyyy");
					}
				case 4:
					{
						return dateToShow.ToString("dd-MM-yyyy HH-mm-ss");
					}
				case 5:
					{
						return dateToShow.ToString("R");
					}
			}
		}
	}
}
