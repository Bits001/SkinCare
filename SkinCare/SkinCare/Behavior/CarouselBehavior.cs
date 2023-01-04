using SkinCare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SkinCare.Behavior
{
    public class CarouselBehavior : Behavior<CarouselView>
    {
        private int previousIndex;

        private void Animation(CarouselView carousel, int selectedIndex)
        {
            if (carousel != null && carousel.ItemsSource != null && carousel.ItemsSource.Cast<object>().Count() > 0)
            {
                int itemsCount = carousel.ItemsSource.Cast<object>().Count();
                int.TryParse(selectedIndex.ToString(), out int index); 

                var items = carousel.ItemsSource.Cast<object>().ToList();

                var currentItem = items[index];
                var childElement = (((currentItem as Onboardings).CarouselItems as ContentView).Children[0] as StackLayout).Children.ToList();
                if(childElement!= null && childElement.Count >0)
                {
                    StartAnimation(childElement, currentItem as Onboardings);
                }

                if(index != previousIndex)
                {
                    var previousItem = items[previousIndex];
                    var previousChildElement = (((previousItem as Onboardings).CarouselItems as ContentView).Children[0] as StackLayout).Children.ToList();
                    
                    if(previousChildElement != null && previousChildElement.Count > 0)
                    {
                        previousChildElement[0].FadeTo(0, 250);
                        previousChildElement[1].FadeTo(0, 250);
                        previousChildElement[1].TranslateTo(0,60, 250);
                        previousChildElement[0].ScaleTo(0.5, 250);
                        previousChildElement[0].FadeTo(0, 250);
                        previousChildElement[0].TranslateTo(0, 60,250);
                    }
                    previousIndex = index;
                }

            }
        }

        private async void StartAnimation(List<View> childElement, Onboardings item)
        {
            var fadeAnimationImage = childElement[0].FadeTo(1, 250);
            var fadeAnimationtaskTitleTime = childElement[1].FadeTo(1, 1000);
            var translateAnimation = childElement[1].TranslateTo(0,0, 500);
            var scaleAnimationTitle = childElement[1].ScaleTo(1, 500, Easing.SinIn);
            var fadeAnimationTaskDescriptionTime = childElement[2].FadeTo(1, 1000);
            var translateDescriptionAnimation = childElement[2].TranslateTo(0, 0, 500);

            var animation =  new Animation();
            var scaleDownAnmation = new Animation(v => childElement[0].Scale = v, 0.5, 1, Easing.SinIn);
            animation.Add(0, 1, scaleDownAnmation);
            animation.Commit(item.CarouselItems as ContentView, "animation", 16, 500);

            await Task.WhenAll(fadeAnimationTaskDescriptionTime, fadeAnimationtaskTitleTime, translateAnimation, scaleAnimationTitle, fadeAnimationImage, fadeAnimationtaskTitleTime);
        }
        
        protected override void OnAttachedTo(CarouselView carousel)
        {
            base.OnAttachedTo(carousel);
            carousel.PositionChanged += Carousel_PositionChanged;
            carousel.BindingContextChanged += Carousel_BindingContextChanged;
        }

        protected override void OnDetachingFrom(CarouselView carousel)
        {
            base.OnDetachingFrom(carousel);
            carousel.PositionChanged += Carousel_PositionChanged;
            carousel.BindingContextChanged += Carousel_BindingContextChanged;
        }
       
      

        private void Carousel_BindingContextChanged(object sender, EventArgs e)
        {
            Task.Delay(500).ContinueWith(t => Animation(sender as CarouselView, 0));
        }

        private void Carousel_PositionChanged(object sender, PositionChangedEventArgs e)
        {
            CarouselView carousel = sender as CarouselView;
            Animation(carousel, e.CurrentPosition);
        }

    }
}
