//-------------------------------------------------------------------------------------------------
// <copyright file="WixGroupLabel.cs" company="Microsoft">
//    Copyright (c) Microsoft Corporation.  All rights reserved.
//    
//    The use and distribution terms for this software are covered by the
//    Common Public License 1.0 (http://opensource.org/licenses/cpl1.0.php)
//    which can be found in the file CPL.TXT at the root of this distribution.
//    By using this software in any fashion, you are agreeing to be bound by
//    the terms of this license.
//    
//    You must not remove this notice, or any other, from this software.
// </copyright>
// 
// <summary>
// Contains the WixGroupLabel class.
// </summary>
//-------------------------------------------------------------------------------------------------

namespace Microsoft.Tools.WindowsInstallerXml.VisualStudio.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// A label with a group line extending past the text. Used for the group headings on the property pages.
    /// </summary>
    internal class WixGroupLabel : Label
    {
        // =========================================================================================
        // Member Variables
        // =========================================================================================

        private const int LabelLineSpacing = 4;

        // =========================================================================================
        // Constructors
        // =========================================================================================

        /// <summary>
        /// Initializes a new instance of the <see cref="WixGroupLabel"/> class.
        /// </summary>
        public WixGroupLabel()
        {
            this.InitializeComponent();
        }

        // =========================================================================================
        // Properties
        // =========================================================================================

        /// <summary>
        /// Gets or sets a value indicating whether the control is automatically resized to display its entire contents.
        /// </summary>
        [DefaultValue(false)]
        public override bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }

        // =========================================================================================
        // Methods
        // =========================================================================================

        /// <summary>
        /// Paints the control.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> object that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // paint the line
            Pen pen = SystemPens.ControlDarkDark;
            int middleY = (int)((this.ClientRectangle.Height - this.Padding.Size.Height) / 2 - pen.Width / 2) + 1 + this.Padding.Top;
            e.Graphics.DrawLine(pen, this.PreferredWidth + LabelLineSpacing, middleY, this.ClientRectangle.Width, middleY);
        }

        /// <summary>
        /// Sets the bounds of the control.
        /// </summary>
        /// <param name="x">The new left position.</param>
        /// <param name="y">The new top position.</param>
        /// <param name="width">The new width.</param>
        /// <param name="height">The new height.</param>
        /// <param name="specified">Which of the bounds should be set.</param>
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if ((specified & BoundsSpecified.Height) == BoundsSpecified.Height)
            {
                height = this.PreferredHeight;
            }

            base.SetBoundsCore(x, y, width, height, specified);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
}
