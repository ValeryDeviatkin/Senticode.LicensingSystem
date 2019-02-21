using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace Senticode.WPF.Tools.Core
{
    public class ObservableRangeCollection<T> : ObservableCollection<T>
    {
        public ObservableRangeCollection()
        {
        }

        public ObservableRangeCollection(IEnumerable<T> collection)
            : base(collection)
        {
        }

        public virtual void AddRange(IEnumerable<T> collection,
            NotifyCollectionChangedAction notificationMode = NotifyCollectionChangedAction.Add)
        {
            collection = collection.ToArray();

            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            CheckReentrancy();

            if (notificationMode == NotifyCollectionChangedAction.Reset)
            {
                foreach (var i in collection)
                {
                    Items.Add(i);
                }

                OnPropertyChanged(new PropertyChangedEventArgs("Count"));
                OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

                return;
            }

            var startIndex = Count;

            foreach (var i in collection)
            {
                Items.Add(i);
            }

            OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            OnCollectionChanged(
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, (IList) collection, startIndex));
        }

        /// <summary>
        ///     Removes the first occurrence of each item in the specified collection from ObservableCollection(Of T).
        /// </summary>
        public virtual void RemoveRange(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            foreach (var i in collection)
            {
                Items.Remove(i);
            }

            OnCollectionChanged(
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, (IList) collection));
        }

        /// <summary>
        ///     Clears the current collection and replaces it with the specified item.
        /// </summary>
        public virtual void Replace(T item)
        {
            ReplaceRange(new[] { item });
        }

        /// <summary>
        ///     Clears the current collection and replaces it with the specified collection.
        /// </summary>
        public virtual void ReplaceRange(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            Items.Clear();
            AddRange(collection, NotifyCollectionChangedAction.Reset);
        }

        public void UpdateViews()
        {
            OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace,
                (IList)Items, (IList)Items));
        }
    }
}