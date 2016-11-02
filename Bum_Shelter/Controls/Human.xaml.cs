using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace Bum_Shelter.Controls
{
    /// <summary>
    /// Логика взаимодействия для Human.xaml
    /// </summary>
    public partial class Human : UserControl
    {
        DispatcherTimer timer;

        Transform InstanceRightLegRT;
        Transform InstanceLeftLegRT;
        Transform InstanceLeftArmRT;
        Transform InstanceRightArmRT;

        RotateTransform RightLegRT = new RotateTransform();
        RotateTransform LeftLegRT = new RotateTransform();
        RotateTransform LeftArmRT = new RotateTransform();
        RotateTransform RightArmRT = new RotateTransform();
        float LegMaxAngle = -20;
        float LegMinAngle = 20;
        float ArmMaxAngle = -20;
        float ArmMinAngle = 20;

        public Thickness distanation;

        public enum HumanState
        {
            isStanding,
            isWalking,
            isWorking
        }
        public HumanState humanState;

        #region Directions
        enum Direction
        {
            Up,
            Down
        }
        Direction RightLegDirection = Direction.Up;
        Direction LeftLegDirection = Direction.Down;
        Direction RightArmDirection = Direction.Up;
        Direction LeftArmDirection = Direction.Up;
        #endregion

        public Human()
        {
            InitializeComponent();
            InstanceRightLegRT = RightLeg.RenderTransform;
            InstanceLeftLegRT = LeftLeg.RenderTransform;
            InstanceLeftArmRT = LeftArm.RenderTransform;
            InstanceRightArmRT = RightArm.RenderTransform;
            humanState = HumanState.isStanding;
        }

        public void WalkingAnimation()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void StopWalkingAnimation()
        {
            timer.Stop();
            LeftArm.RenderTransform = InstanceLeftArmRT;
            RightArm.RenderTransform = InstanceRightArmRT;
            LeftLeg.RenderTransform = InstanceLeftLegRT;
            RightLeg.RenderTransform = InstanceRightLegRT;
            humanState = HumanState.isStanding;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            #region RightLegAnim

            if (RightLegDirection == Direction.Up)
            {
                if (RightLegRT.Angle > LegMaxAngle)
                {
                    RightLegRT.Angle -= 5;
                }
                else
                {
                    RightLegDirection = Direction.Down;
                }
            }
            else if(RightLegDirection == Direction.Down)
            {
                {
                    if (RightLegRT.Angle < LegMinAngle)
                    {
                        RightLegRT.Angle += 5;
                    }
                    else
                    {
                        RightLegDirection = Direction.Up;
                    }
                }
            }
            RightLeg.RenderTransform = RightLegRT;
            #endregion

            #region LeftLegAnim

            if (LeftLegDirection == Direction.Up)
            {
                if (LeftLegRT.Angle > LegMaxAngle)
                {
                    LeftLegRT.Angle -= 5;
                }
                else
                {
                    LeftLegDirection = Direction.Down;
                }
            }
            else if (LeftLegDirection == Direction.Down)
            {
                {
                    if (LeftLegRT.Angle < LegMinAngle)
                    {
                        LeftLegRT.Angle += 5;
                    }
                    else
                    {
                        LeftLegDirection = Direction.Up;
                    }
                }
            }
            LeftLeg.RenderTransform = LeftLegRT;
            #endregion

            #region LeftArmAnim

            if (LeftArmDirection == Direction.Up)
            {
                if (LeftArmRT.Angle > ArmMaxAngle)
                {
                    LeftArmRT.Angle -= 5;
                }
                else
                {
                    LeftArmDirection = Direction.Down;
                }
            }
            else if (LeftArmDirection == Direction.Down)
            {
                {
                    if (LeftArmRT.Angle < ArmMinAngle)
                    {
                        LeftArmRT.Angle += 5;
                    }
                    else
                    {
                        LeftArmDirection = Direction.Up;
                    }
                }
            }
            LeftArm.RenderTransform = LeftArmRT;
            #endregion

            #region RightArmAnim

            if (RightArmDirection == Direction.Up)
            {
                if (RightArmRT.Angle > ArmMaxAngle)
                {
                    RightArmRT.Angle -= 5;
                }
                else
                {
                    RightArmDirection = Direction.Down;
                }
            }
            else if (RightArmDirection == Direction.Down)
            {
                {
                    if (RightArmRT.Angle < ArmMinAngle)
                    {
                        RightArmRT.Angle += 5;
                    }
                    else
                    {
                        RightArmDirection = Direction.Up;
                    }
                }
            }
            TransformGroup TG = new TransformGroup();
            ScaleTransform ST = new ScaleTransform();
            ST.ScaleX = -1;
            TG.Children.Add(RightArmRT);
            TG.Children.Add(ST);
            RightArm.RenderTransform = TG;
            #endregion
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (humanState != HumanState.isWalking)
            {
                Constants.choosenHuman = this;
            }
        }

        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Constants.choosenHuman = null;
        }

        //ДВИЖЕНИЕ

        public void Move()
        {
            ThicknessAnimation anim = new ThicknessAnimation();
            anim.From = Margin;
            anim.To = distanation;
            anim.Duration = TimeSpan.FromSeconds(3);
            anim.Completed += AnimCompleted;
            BeginAnimation(MarginProperty, anim);
            WalkingAnimation();
        }

        private void AnimCompleted(object sender, EventArgs e)
        {
            StopWalkingAnimation();
        }
    }
}
