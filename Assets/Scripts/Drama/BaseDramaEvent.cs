using System.Collections;

//腳本事件的基底
namespace DramaEvent
{
    public abstract class BaseDramaEvent
    {
        protected BaseDramaEvent () { }

        public bool IsRunning;              //using WaitForSeconds

        public virtual IEnumerator Play ()
        {
            yield return null;
        }
    }
}