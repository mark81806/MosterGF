using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DramaEvent
{
    public class CheckEventt : BaseDramaEvent 
    {
        public string[] events;

        public CheckEventt() : this(new string[] { })
        { }
        public CheckEventt(string[] events)
        {
            this.events = events;
        }

    }
}