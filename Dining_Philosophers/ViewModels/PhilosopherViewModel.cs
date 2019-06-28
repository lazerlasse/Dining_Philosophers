using Dining_Philosophers.Models;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Dining_Philosophers.Delegates;
using Dining_Philosophers.Simulator;

namespace Dining_Philosophers.ViewModels
{
	class PhilosopherViewModel : BaseViewModel
	{
		// Private properties for philosopher hands.
		private bool philosopher0_RightHand;
		private bool philosopher1_RightHand;
		private bool philosopher2_RightHand;
		private bool philosopher3_RightHand;
		private bool philosopher4_RightHand;
		private bool philosopher5_RightHand;
		private bool philosopher0_LeftHand;
		private bool philosopher1_LeftHand;
		private bool philosopher2_LeftHand;
		private bool philosopher3_LeftHand;
		private bool philosopher4_LeftHand;
		private bool philosopher5_LeftHand;

		// Private properties for the fork on table.
		private bool forkAtTable0;
		private bool forkAtTable1;
		private bool forkAtTable2;
		private bool forkAtTable3;
		private bool forkAtTable4;
		private bool forkAtTable5;

		// Navigation property.
		public Person person = new Philosopher();
		public DiningSimulation diningSimulation;

		
		// Property for the speed slider.
		private double speedSliderValue;

		// Philosophers right hand properties.
		public bool Philosopher0_RightHand
		{
			get
			{
				return philosopher0_RightHand;
			}
			set
			{
				philosopher0_RightHand = value;
				OnPropertyChanged("Philosopher0_RightHand");
			}
		}
		public bool Philosopher1_RightHand
		{
			get
			{
				return philosopher1_RightHand;
			}
			set
			{
				philosopher1_RightHand = value;
				OnPropertyChanged("Philosopher1_RightHand");
			}
		}
		public bool Philosopher2_RightHand
		{
			get
			{
				return philosopher2_RightHand;
			}
			set
			{
				philosopher2_RightHand = value;
				OnPropertyChanged("Philosopher2_RightHand");
			}
		}
		public bool Philosopher3_RightHand
		{
			get
			{
				return philosopher3_RightHand;
			}
			set
			{
				philosopher3_RightHand = value;
				OnPropertyChanged("Philosopher3_RightHand");
			}
		}
		public bool Philosopher4_RightHand
		{
			get
			{
				return philosopher4_RightHand;
			}
			set
			{
				philosopher4_RightHand = value;
				OnPropertyChanged("Philosopher4_RightHand");
			}
		}
		public bool Philosopher5_RightHand
		{
			get
			{
				return philosopher5_RightHand;
			}
			set
			{
				philosopher5_RightHand = value;
				OnPropertyChanged("Philosopher5_RightHand");
			}
		}

		// Philosophers left hand public properties.
		public bool Philosopher0_LeftHand
		{
			get
			{
				return philosopher0_LeftHand;
			}
			set
			{
				philosopher0_LeftHand = value;
				OnPropertyChanged("Philosopher0_LeftHand");
			}
		}
		public bool Philosopher1_LeftHand
		{
			get
			{
				return philosopher1_LeftHand;
			}
			set
			{
				philosopher1_LeftHand = value;
				OnPropertyChanged("Philosopher1_LeftHand");
			}
		}
		public bool Philosopher2_LeftHand
		{
			get
			{
				return philosopher2_LeftHand;
			}
			set
			{
				philosopher2_LeftHand = value;
				OnPropertyChanged("Philosopher2_LeftHand");
			}
		}
		public bool Philosopher3_LeftHand
		{
			get
			{
				return philosopher3_LeftHand;
			}
			set
			{
				philosopher3_LeftHand = value;
				OnPropertyChanged("Philosopher3_LeftHand");
			}
		}
		public bool Philosopher4_LeftHand
		{
			get
			{
				return philosopher4_LeftHand;
			}
			set
			{
				philosopher4_LeftHand = value;
				OnPropertyChanged("Philosopher4_LeftHand");
			}
		}
		public bool Philosopher5_LeftHand
		{
			get
			{
				return philosopher5_LeftHand;
			}
			set
			{
				philosopher5_LeftHand = value;
				OnPropertyChanged("Philosopher5_LeftHand");
			}
		}

		// Forks at the table properties...
		public bool ForkAtTable0
		{
			get
			{
				return forkAtTable0;
			}
			set
			{
				forkAtTable0 = value;
				OnPropertyChanged("ForkAtTable0");
			}
		}
		public bool ForkAtTable1
		{
			get
			{
				return forkAtTable1;
			}
			set
			{
				forkAtTable1 = value;
				OnPropertyChanged("ForkAtTable1");
			}
		}
		public bool ForkAtTable2
		{
			get
			{
				return forkAtTable2;
			}
			set
			{
				forkAtTable2 = value;
				OnPropertyChanged("ForkAtTable2");
			}
		}
		public bool ForkAtTable3
		{
			get
			{
				return forkAtTable3;
			}
			set
			{
				forkAtTable3 = value;
				OnPropertyChanged("ForkAtTable3");
			}
		}
		public bool ForkAtTable4
		{
			get
			{
				return forkAtTable4;
			}
			set
			{
				forkAtTable4 = value;
				OnPropertyChanged("ForkAtTable4");
			}
		}
		public bool ForkAtTable5
		{
			get
			{
				return forkAtTable5;
			}
			set
			{
				forkAtTable5 = value;
				OnPropertyChanged("ForkAtTable5");
			}
		}

		private bool ForkRightHand
		{
			get
			{
				if (person.ID == 0)
				{
					Philosopher0_RightHand = person.HasRightFork;
					return Philosopher0_RightHand;
				}
				else if (person.ID == 1)
				{
					Philosopher1_RightHand = person.HasRightFork;
					return Philosopher1_RightHand;
				}
				else if (person.ID == 2)
				{
					Philosopher2_RightHand = person.HasRightFork;
					return Philosopher2_RightHand;
				}
				else if (person.ID == 3)
				{
					Philosopher3_RightHand = person.HasRightFork;
					return Philosopher3_RightHand;
				}
				else if (person.ID == 4)
				{
					Philosopher4_RightHand = person.HasRightFork;
					return Philosopher4_RightHand;
				}
				else if (person.ID == 5)
				{
					Philosopher5_RightHand = person.HasRightFork;
					return Philosopher5_RightHand;
				}
				else
				{
					return person.HasRightFork;
				}
			}
			set
			{
				if (person.ID == 0)
				{
					Philosopher0_RightHand = person.HasRightFork;
					OnPropertyChanged("Philosopher0_RightHand");
				}
				else if (person.ID == 1)
				{
					Philosopher1_RightHand = person.HasRightFork;
					OnPropertyChanged("Philosopher1_RightHand");
				}
				else if (person.ID == 2)
				{
					Philosopher2_RightHand = person.HasRightFork;
					OnPropertyChanged("Philosopher2_RightHand");
				}
				else if (person.ID == 3)
				{
					Philosopher3_RightHand = person.HasRightFork;
					OnPropertyChanged("Philosopher3_RightHand");
				}
				else if (person.ID == 4)
				{
					Philosopher4_RightHand = person.HasRightFork;
					OnPropertyChanged("Philosopher4_RightHand");
				}
				else if (person.ID == 5)
				{
					Philosopher5_RightHand = person.HasRightFork;
					OnPropertyChanged("Philosopher5_RightHand");
				}

				UpdateForkOnTable(person.RightForkId);
			}
		}

		private bool ForkLeftHand
		{
			get
			{
				if (person.ID == 0)
				{
					Philosopher0_LeftHand = person.HasLeftFork;
					return Philosopher0_LeftHand;
				}
				else if (person.ID == 1)
				{
					Philosopher1_LeftHand = person.HasLeftFork;
					return Philosopher1_LeftHand;
				}
				else if (person.ID == 2)
				{
					Philosopher2_LeftHand = person.HasLeftFork;
					return Philosopher2_LeftHand;
				}
				else if (person.ID == 3)
				{
					Philosopher3_LeftHand = person.HasLeftFork;
					return Philosopher3_LeftHand;
				}
				else if (person.ID == 4)
				{
					Philosopher4_LeftHand = person.HasLeftFork;
					return Philosopher4_LeftHand;
				}
				else if (person.ID == 5)
				{
					Philosopher5_LeftHand = person.HasLeftFork;
					return Philosopher5_LeftHand;
				}
				else
				{
					return person.HasLeftFork;
				}
			}
			set
			{
				if (person.ID == 0)
				{
					Philosopher0_LeftHand = person.HasLeftFork;
					OnPropertyChanged("Philosopher0_LeftHand");
				}
				else if (person.ID == 1)
				{
					Philosopher1_LeftHand = person.HasLeftFork;
					OnPropertyChanged("Philosopher1_LeftHand");
				}
				else if (person.ID == 2)
				{
					Philosopher2_LeftHand = person.HasLeftFork;
					OnPropertyChanged("Philosopher2_LeftHand");
				}
				else if (person.ID == 3)
				{
					Philosopher3_LeftHand = person.HasLeftFork;
					OnPropertyChanged("Philosopher3_LeftHand");
				}
				else if (person.ID == 4)
				{
					Philosopher4_LeftHand = person.HasLeftFork;
					OnPropertyChanged("Philosopher4_LeftHand");
				}
				else if (person.ID == 5)
				{
					Philosopher5_LeftHand = person.HasLeftFork;
					OnPropertyChanged("Philosopher5_LeftHand");
				}

				UpdateForkOnTable(person.LeftForkId);
			}
		}

		public ICommand StartButton { get; set; }
		public ICommand ResetButton { get; set; }

		public double SpeedSliderValue
		{
			get
			{
				return person.ThinkingTime;
			}
			set
			{
				person.ThinkingTime = value;
				OnPropertyChanged("SpeedSliderValue");
			}
		}

		public PhilosopherViewModel()
		{
			// Set the simulation to use.
			// Added amout of philosophers static..... Change this to binding......
			diningSimulation = new DiningSimulation(6);

			// Create new delegate commands for the buttons in PhilosophersView.
			StartButton = new DelegateCommand(new Action<object>(StartButtonAction));
			ResetButton = new DelegateCommand(new Action<object>(ResetButtonAction));
		}

		private void StartButtonAction(object obj)
		{
			diningSimulation.Start();
		}

		private void ResetButtonAction(object obj)
		{
			diningSimulation.Reset();
		}

		private void UpdateForkOnTable(int id)
		{
			if (id == 0)
			{
				ForkAtTable0 = CheckTrueFalse(ForkAtTable0);
				OnPropertyChanged("ForkAtTable0");
			}
			if (id == 1)
			{
				ForkAtTable1 = CheckTrueFalse(ForkAtTable1);
				OnPropertyChanged("ForkAtTable1");
			}
			if (id == 2)
			{
				ForkAtTable2 = CheckTrueFalse(ForkAtTable2);
				OnPropertyChanged("ForkAtTable2");
			}
			if (id == 3)
			{
				ForkAtTable3 = CheckTrueFalse(ForkAtTable3);
				OnPropertyChanged("ForkAtTable3");
			}
			if (id == 4)
			{
				ForkAtTable4 = CheckTrueFalse(ForkAtTable4);
				OnPropertyChanged("ForkAtTable4");
			}
			if (id == 5)
			{
				ForkAtTable5 = CheckTrueFalse(ForkAtTable5);
				OnPropertyChanged("ForkAtTable5");
			}
		}

		private bool CheckTrueFalse(bool value)
		{
			if (value == true)
			{
				value = false;
			}
			else
			{
				value = true;
			}

			return value;
		}
	}
}
