/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/07
Description:
    简介：事件管理器
    作用：集中管理游戏中的UnityEvent事件和EventHandler事件，注册、移除、调用事件均通过这个系统
    使用：推荐用UEvent和SEvent，ArgEvent事件经测试在绑定多个Listener时有无法预估的错误，慎用！
    补充：协定事件如果要传递bool参数，则若参数为null即false，若不为null即为true
History:
    TODO:对于重复的EventHandler，是否要拒绝其Listen，在考虑中
    TODO：事件比委托更好
----------------------------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;       // EventArgs需要

namespace SFramework
{
    /// <summary>
    /// 事件系统
    /// </summary>
    public class EventMgr : Singleton<EventMgr>
    {
        public delegate void EventHandler(object sender, EventArgs e);

        private EventHandler testEvent;
        private event EventHandler eventHandler;

        private Dictionary<UEvent, UnityEvent> events;
        private Dictionary<ArgEvent, EventHandler> eventHandlers;
        private Dictionary<SEvent, UnityEvent<object, object>> actions;

        public EventMgr()
        {
            events = new Dictionary<UEvent, UnityEvent>();
            eventHandlers = new Dictionary<ArgEvent, EventHandler>();
            actions = new Dictionary<SEvent, UnityEvent<object, object>>();
        }

        /// <summary>
        /// 注册监听事件，如果字典中不存在那么创建
        /// </summary>
        /// <param name="uEvent"></param>
        /// <param name="listener"></param>
        public void Listen(UEvent uEvent, UnityAction listener)
        {
            if (events.TryGetValue(uEvent, out var thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                events.Add(uEvent, thisEvent);
            }
        }

        /// <summary>
        /// 移除监听事件
        /// </summary>
        /// <param name="uEvent"></param>
        /// <param name="listener"></param>
        public void Remove(UEvent uEvent, UnityAction listener)
        {
            if (events.TryGetValue(uEvent, out var thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        /// <summary>
        /// 触发指定事件
        /// </summary>
        /// <param name="uEvent"></param>
        public void Invoke(UEvent uEvent)
        {
            if (events.TryGetValue(uEvent, out var thisEvent))
            {
                thisEvent.Invoke();
            }
        }

        /// <summary>
        /// 注册监听事件，如果字典中不存在那么创建
        /// </summary>
        /// <param name="argEventName"></param>
        /// <param name="listener"></param>
        public void Listen(ArgEvent argEventName, EventHandler listener)
        {
            if (eventHandlers.TryGetValue(argEventName, out var thisEvent))
            {
                thisEvent = thisEvent + listener;
            }
            else
            {
                thisEvent = listener;
                eventHandlers.Add(argEventName, thisEvent);
            }
        }

        /// <summary>
        /// 移除监听事件
        /// </summary>
        /// <param name="argEventName"></param>
        /// <param name="listener"></param>
        public void Remove(ArgEvent argEventName, EventHandler listener)
        {
            EventHandler thisEvent = null;
            if (eventHandlers.TryGetValue(argEventName, out thisEvent))
            {
                thisEvent -= listener;
            }
        }

        /// <summary>
        /// 触发指定事件
        /// </summary>
        /// <param name="argEventName"></param>
        public void Invoke(ArgEvent argEventName, object sender, EventArgs e)
        {
            if (eventHandlers.TryGetValue(argEventName, out var thisEvent))
            {
                thisEvent(sender, e);
            }
        }

        public void Listen(SEvent sEvent, UnityAction<object, object> listener)
        {
            if (actions.TryGetValue(sEvent, out var thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent= new SFrameEvent();
                thisEvent.AddListener(listener);
                actions.Add(sEvent, thisEvent);
            }
        }

        public void Remove(SEvent sEvent, UnityAction<object, object> listener)
        {
            if (actions.TryGetValue(sEvent, out var thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        public void Invoke(SEvent sEvent, object sender, object args)
        {
            if (actions.TryGetValue(sEvent, out var thisEvent))
            {
                thisEvent.Invoke(sender, args);
            }
        }

    }
}