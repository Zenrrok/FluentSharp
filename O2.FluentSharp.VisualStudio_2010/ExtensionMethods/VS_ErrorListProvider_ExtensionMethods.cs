﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using O2.FluentSharp;

namespace O2.DotNetWrappers.ExtensionMethods
{
    public static class VS_ExtensionMethods
    {
    	public static ErrorListProvider errorList(this VisualStudio_2010 visualStudio)
    	{
    		return VisualStudio_2010.ErrorListProvider;
    	}
    	
    	public static ErrorListProvider errorList(this ErrorTask task)
    	{
    		return VisualStudio_2010.ErrorListProvider;
    	}
    	
        public static ErrorListProvider clear(this ErrorListProvider errorListProvider)
        {
            errorListProvider.Tasks.Clear();
            return errorListProvider;
        }

        public static ErrorTask add_Error(this string text)
        {
            return VisualStudio_2010.ErrorListProvider.add_Error(text);
        }

        public static ErrorTask add_Error(this ErrorListProvider errorListProvider, string text, int line = 1, int column= 1)
        {
            return errorListProvider.add_Task(TaskErrorCategory.Error, text, line, column);
        }

        public static ErrorTask add_Warning(this string text)
        {
            return VisualStudio_2010.ErrorListProvider.add_Warning(text);
        }

        public static ErrorTask add_Warning(this ErrorListProvider errorListProvider, string text)
        {
            return errorListProvider.add_Task(TaskErrorCategory.Warning, text);
        }

        public static ErrorTask add_Message(this string text)
        {
            return VisualStudio_2010.ErrorListProvider.add_Message(text);
        }
        public static ErrorTask add_Message(this ErrorListProvider errorListProvider, string text)
        {
            return errorListProvider.add_Task(TaskErrorCategory.Message, text);
        }
        public static ErrorTask add_Task(this ErrorListProvider errorListProvider, TaskErrorCategory errorCategory, string text, int line = 1, int column= 1)
        {
            var errorTask = new ErrorTask()
            {
                ErrorCategory = errorCategory,
                Category = TaskCategory.BuildCompile,
                Text = text,
                //Document 	 = firstFileInProject, 
                Line = line -1,
                Column = column -1,
                //HierarchyItem = hierarchyItem			
            };
            errorListProvider.Tasks.Add(errorTask);
            return errorTask;
        }
    }
}
