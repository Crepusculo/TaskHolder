using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Animation;

namespace App1.Animation
{
    class PageTransitions
    {
        public static TransitionCollection SetUpPageAnimation(int idx = 0)
        {
            TransitionCollection collection = new TransitionCollection();
            NavigationThemeTransition theme = new NavigationThemeTransition();
            switch (idx)
            {
                case 1:
                    theme.DefaultNavigationTransitionInfo = new ContinuumNavigationTransitionInfo();
                    break;
                case 2:
                    theme.DefaultNavigationTransitionInfo = new CommonNavigationTransitionInfo();
                    break;
                case 3:
                    theme.DefaultNavigationTransitionInfo = new DrillInNavigationTransitionInfo();
                    break;
                case 4:
                    theme.DefaultNavigationTransitionInfo = new EntranceNavigationTransitionInfo();
                    break;
                case 5:
                    theme.DefaultNavigationTransitionInfo = new SuppressNavigationTransitionInfo();
                    break;
                default:
                    var info = new SlideNavigationTransitionInfo();
                    theme.DefaultNavigationTransitionInfo = info;
                    break;
            }

            collection.Add(theme);
            var transitions = collection;
            return transitions;
        }
    }
}