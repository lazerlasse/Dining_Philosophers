using Dining_Philosophers.Models;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Dining_Philosophers.Delegates;

namespace Dining_Philosophers.ViewModels
{
	class PhilosopherViewModel : BaseViewModel
	{
		// Property changed property for person model.
		private Person person;

		// Property for the speed slider.
		private double speedSliderValue;

		// Properties for philosophers hands.
		private bool philosopher1_RightHandForkVisible;
		private bool philosopher1_LeftHandForkVisible;

		public bool ForkRightHand
		{
			get
			{
				return person.HasRightFork;
			}
			set
			{
				if (person.ID == 0)
				{
					philosopher1_RightHandForkVisible = value;
				}
				person.HasRightFork = value;
				
			}
		}

		public double SpeedSliderValue
		{
			get
			{
				return speedSliderValue;
			}
			set
			{
				speedSliderValue = value;
				OnPropertyChanged("SpeedSliderValue");
			}
		}

		public bool Philosopher1_RightHandForkVisible
		{
			get
			{
				return philosopher1_RightHandForkVisible;
			}
			set
			{
				philosopher1_RightHandForkVisible = value;
				OnPropertyChanged("Philosopher1_RightHandForkEnable");
			}
		}

		public bool Philosopher1_LeftHandForkVisible
		{
			get
			{
				return philosopher1_LeftHandForkVisible;
			}
			set
			{
				philosopher1_LeftHandForkVisible = value;
				OnPropertyChanged("Philosopher1_LeftHandForkVisible");
			}
		}

		public ICommand StartButton { get; set; }
		public ICommand ResetButton { get; set; }

		public PhilosopherViewModel()
		{
			StartButton = new DelegateCommand(new Action<object>(StartButtonAction));
			ResetButton = new DelegateCommand(new Action<object>(ResetButtonAction));
		}

		private void StartButtonAction(object obj)
		{
			
		}

		private void ResetButtonAction(object obj)
		{

		}

		
	}
}
