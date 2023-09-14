using NaturalSort.Extension;
using System;
using System.Collections.Generic;
using ManagerHelperLocalDb.ViewModels.Support;

namespace ManagerHelperLocalDb.ViewModels
{
    public class ComboBoxItemViewModel<T> : PropertyChangedNotifier, IComparable<ComboBoxItemViewModel<T>>
    {
        private bool _isSelected;
        private string _text = string.Empty;
        private string _icon = string.Empty;
        private T _value;
        private string _shortcutKeyText = string.Empty;

        private static readonly NaturalSortComparer NaturalComparer = new(StringComparison.InvariantCultureIgnoreCase);

        #region Properties

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        public string Icon
        {
            get { return _icon; }
            set
            {
                if (string.Compare(_icon, value) != 0)
                {
                    _icon = value;
                    OnPropertyChanged(nameof(Icon));
                }
            }
        }

        public string Text
        {
            get { return _text; }
            set
            {
                if (string.Compare(_text, value) != 0)
                {
                    _text = value;
                    OnPropertyChanged(nameof(Text));
                }
            }
        }

        public string ShortcutKeyText
        {
            get { return _shortcutKeyText; }
            set
            {
                if (string.Compare(_shortcutKeyText, value) != 0)
                {
                    _shortcutKeyText = value;
                    OnPropertyChanged(nameof(ShortcutKeyText));
                }
            }
        }

        public T Value
        {
            get { return _value; }
            private set
            {
                if (isDataChanged(_value, value))
                {
                    _value = value;
                    OnPropertyChanged(nameof(Value));
                }
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBoxItemViewModel{T}" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="text">The text.</param>
        /// <param name="shortcutText">The shortcut text.</param>
        /// <param name="icon">The icon.</param>
        public ComboBoxItemViewModel(T value, string text, string shortcutText = "", string icon = "")
        {
            _value = value;
            _text = text;
            _shortcutKeyText = shortcutText;
            _icon = icon;
        }

        #region Convenience

        /// <summary>
        /// Determines whether [is data changed] [the specified value1].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns></returns>
        private bool isDataChanged(T value1, T value2)
        {
            return !EqualityComparer<T>.Default.Equals(value1, value2);
        }

        #endregion

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns></returns>
        public ComboBoxItemViewModel<T> Clone()
        {
            return new ComboBoxItemViewModel<T>(_value, _text, _shortcutKeyText, _icon);
        }

        #region IComparable

        /// <summary>
        /// Compares the two items by concatenating the name with the ID.  This way items with the 
        /// same name will always show up in a list in the same order.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        int IComparable<ComboBoxItemViewModel<T>>.CompareTo(ComboBoxItemViewModel<T> other)
        {
            // put null items at the bottom of the list
            if (other == null)
                return -1;

            return NaturalComparer.Compare(Text, other.Text);
        }

        #endregion
    }
}
