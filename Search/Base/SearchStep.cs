using System;
using System.Collections.Generic;
using System.Drawing;

namespace Search.Base
{
    public delegate Bitmap SimulateStepHandler<K>(KeyValuePair<INode<K>, NodeVisitAction> step) where K : class, IComparable<K>;
    public class SearchStep<K> where K : class, IComparable<K>
    {
        public static event SimulateStepHandler<K> OnSimulationRequired;

        public Bitmap GraphCapture
        {
            get { return OnSimulationRequired?.Invoke(StepInformation); }
        }

        public KeyValuePair<INode<K>, NodeVisitAction> StepInformation { get; set; }
    }
}