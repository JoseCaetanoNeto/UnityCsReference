// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace UnityEditor.Experimental.UIElements
{
    public class LayerMaskField : MaskField
    {
        public new class UxmlFactory : UxmlFactory<LayerMaskField, UxmlTraits> {}

        public new class UxmlTraits : MaskField.UxmlTraits {}

        void UpdateLayersInfo()
        {
            // Get the layers : names and values
            string[] layerNames = null;
            int[] layerValues = null;
            TagManager.GetDefinedLayers(ref layerNames, ref layerValues);

            // Create the appropriate lists...
            choices = new List<string>(layerNames);
            choicesMasks = new List<int>(layerValues);
        }

        public LayerMaskField(int defaultMask) : this()
        {
            value = defaultMask;
        }

        public LayerMaskField()
        {
            UpdateLayersInfo();
        }

        internal override void AddMenuItems(GenericMenu menu)
        {
            // We must update the choices and the values since we don't know if they changed...
            UpdateLayersInfo();

            // Create the menu the usual way...
            base.AddMenuItems(menu);
        }
    }
}