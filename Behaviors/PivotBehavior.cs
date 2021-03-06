﻿using System;
using System.Linq;

using Microsoft.Xaml.Interactivity;

using UwpAppWithWindowsTemplateStudio.Helpers;

using Windows.UI.Xaml.Controls;

namespace UwpAppWithWindowsTemplateStudio.Behaviors
{
    public class PivotBehavior : Behavior<Pivot>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += OnSelectionChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SelectionChanged -= OnSelectionChanged;
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var removedItem = e.RemovedItems.Cast<PivotItem>()
                .Select(i => GetPivotPage(i)).FirstOrDefault();

            var addedItem = e.AddedItems.Cast<PivotItem>()
                .Select(i => GetPivotPage(i)).FirstOrDefault();

            if (removedItem != null)
            {
                await removedItem.OnPivotUnselectedAsync();
            }

            if (addedItem != null)
            {
                await addedItem?.OnPivotSelectedAsync();
            }
        }

        private static IPivotPage GetPivotPage(PivotItem pivotItem)
        {
            if (pivotItem.Content is Frame frame)
            {
                if (frame.Content is IPivotPage pivotPage)
                {
                    return pivotPage;
                }
            }

            return null;
        }
    }
}
