using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabExerciseWeek12.EmployeeData
{
	public abstract class Karyawan
	{
		public string NIK {get;set;}
		public string Nama {get;set;}
        
		public abstract double Gaji();
	}
}
