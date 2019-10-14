﻿namespace ALE.ETLBox.ControlFlow
{
    public abstract class IfExistsTask : GenericTask, ITask
    {
        public override string TaskName => $"Check if {ObjectName} exists";
        public void Execute()
        {
            if (Sql != string.Empty)
                DoesExist = new SqlTask(this, Sql).ExecuteScalarAsBool();
        }

        public string ObjectName { get; set; }
        internal string OnObjectName { get; set; }
        public bool DoesExist { get; private set; }

        public string Sql
        {
            get
            {
                return GetSql();
            }
        }

        internal virtual string GetSql()
        {
            return string.Empty;
        }

        public virtual bool Exists()
        {
            Execute();
            return DoesExist;
        }
    }
}