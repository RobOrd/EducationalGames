using DrWPF.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace LoopPanelSample
{

    //b     k   s
    //c     l   t
    //d     m   v
    //f     n   w
    //g     p   x
    //h     q   y
    //j     r   z

    public partial class AppWindow
    {
        Random rand = new Random();
        Storyboard sb = new Storyboard();
        DoubleAnimation slotAnimation = new DoubleAnimation();
        double? animation_from = 0;

        public AppWindow()
        {
            this.InitializeComponent();

            Init();
        }

        void OnToolBarButtonClick(object sender, RoutedEventArgs e)
        {
            //int index = 3; // int.Parse((e.OriginalSource as Button).Content.ToString());
            //llb.SelectedIndex = index;
            //(llb.ItemContainerGenerator.ContainerFromItem(llb.Items[index]) as ListBoxItem).Focus();

            RunSlot();
        }

        private void Init()
        {
            slotAnimation.EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseInOut };
            slotAnimation.RepeatBehavior = new RepeatBehavior(1);
            slotAnimation.Completed += SlotAnimation_Completed;

            Storyboard.SetTarget(slotAnimation, llb);
            Storyboard.SetTargetProperty(slotAnimation, new PropertyPath(LoopingListBox.OffsetProperty));

            sb = new Storyboard();
            sb.Children.Add(slotAnimation);
        }
        private void RunSlot()
        {
            var distance = rand.Next(4, 13);
            var duration = (distance / 3) + 3.33;

            lstBox.Items.Add(distance);

            //slotAnimation.From = distance - 10;
            animation_from = animation_from ?? slotAnimation.From;
            var animation_to = animation_from + (distance * 13);

            slotAnimation.To = animation_to;
            slotAnimation.Duration = new Duration(TimeSpan.FromSeconds(duration));
            sb.Begin();

            animation_from = animation_to;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sb.Stop();
        }
        private void SlotAnimation_Completed(object sender, EventArgs e)
        {
            //lstBox.Items.Add(llb.Items.CurrentItem);
        }
    }
}