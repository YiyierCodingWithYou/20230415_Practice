using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Person> employees = new List<Person>();
			{
				var one = new Person()
				{
					Name = "SiHyuk",
					Gender = true,
				};
				employees.Add(one);

				var two = new Employee()
				{
					Name = "SeokJin",
					Gender = true,
					BadgeNumber = "B001",
					Salary = 55000,
				};
				employees.Add(two);

				var three = new Sales()
				{
					Name = "NamJoon",
					Gender = true,
					BadgeNumber = "B004",
					Salary = 55000,
					Bonus = 6500
				};
				employees.Add(three);

				var four = new Engineer()
				{
					Name = "YoonGi",
					Gender = true,
					BadgeNumber = "B002",
					Salary = 65000,
					OverTimePay = 20000
				};
				employees.Add(four);

				var six = new Cleaner()
				{
					Name = "Yiyier",
					Gender = false,
					BadgeNumber = "A613",
					Salary = 40000
				};
				employees.Add(six);

				var five = new Manager(new Employee[] { four, six })
				{
					Name = "Taehyung",
					Gender = true,
					BadgeNumber = "B006",
					Salary = 57000
				};
				employees.Add(five);
			}

			foreach (Person item in employees)
			{
				Console.WriteLine(item.GetDescription());
				Console.WriteLine();
			};
		}
	}
	class Person
	{
		public string Name { get; set; }
		public bool Gender { get; set; }

		public virtual string GetDescription()
		{
			return $"姓名：{Name}\n性別：{(Gender ? "男" : "女")} ";
		}
	}
	class Employee : Person
	{
		public string BadgeNumber { get; set; }
		public int Salary { get; set; }

		public override string GetDescription()
		{
			return $"姓名：{Name}\n性別：{(Gender ? "男" : "女")}\n員工編號：{BadgeNumber}\n薪資：{CalcTotalSalary()} ";
		}
		public virtual int CalcTotalSalary() => Salary;
	}

	class Engineer : Employee
	{
		public int OverTimePay { get; set; }
		public override int CalcTotalSalary() => Salary + OverTimePay;
	}
	class Sales : Employee
	{
		public int Bonus { get; set; }
		public override int CalcTotalSalary() => Salary + Bonus;
		
	}
	class Manager : Employee
	{
		public int LeaderBonus { get; set; }
		public Employee[] TeamMember { get; set; }
		public Manager(Employee[] teamMember) // 傳入其他類別的陣列
		{

			this.TeamMember = teamMember;
			LeaderBonus = TeamMember.Length * 10000;
		}
		public override int CalcTotalSalary() => Salary + LeaderBonus;
	}
	class Cleaner : Employee
	{

	}
}
