using System;
using System.Text;
using Microsoft.Build.Framework;

namespace Util.Domain
{
    /// <summary>
    /// 领域实体
    /// </summary>
    /// <typeparam name="TKey">标识类型</typeparam>
    public abstract class EntityBase<TKey>
    {
        protected EntityBase(TKey id)
        {
            Id = id;
        }
        /// <summary>
        /// 标识
        /// </summary>
        [Required]
        public TKey Id { get; private set; }

        private StringBuilder _description;

        #region 重写Equals GetHasCode == !=
        /// <summary>
        /// 相等运算
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool Equals(object entity)
        {
            if (entity == null)
                return false;
            if (!(entity is EntityBase<TKey>))
                return false;
            return this == (EntityBase<TKey>) entity;
        }

        /// <summary>
        /// 获取哈希
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// 重写等于操作符
        /// </summary>
        /// <param name="entity1"></param>
        /// <param name="entity2"></param>
        /// <returns></returns>
        public static bool operator ==(EntityBase<TKey> entity1,EntityBase<TKey> entity2)
        {
            if (entity1 == null && entity2 == null)
                return true;
            if (entity1 == null || entity2 == null)
                return false;
            if (entity1.Id == null)
                return false;
            if (entity1.Id.Equals(default(TKey)))
                return false;
            return entity1.Id.Equals(entity2.Id);
        }

        /// <summary>
        /// 重写不等于操作符
        /// </summary>
        /// <param name="entity1"></param>
        /// <param name="entity2"></param>
        /// <returns></returns>
        public static bool operator !=(EntityBase<TKey> entity1, EntityBase<TKey> entity2)
        {
            return !(entity1 == entity2);
        }
        #endregion

        #region 重写ToString
        public override string ToString()
        {
            _description=new StringBuilder();
            AddDescriptions();
            return _description.ToString().TrimEnd().TrimEnd(',');
        }

        protected virtual void AddDescriptions()
        {
        }

        protected void AddDescription(string description)
        {
            if(string.IsNullOrWhiteSpace(description))
                return;
            _description.Append(description);
        }

        protected void AddDescription<T>( string name, T value ) {
            if ( string.IsNullOrWhiteSpace( value.ToString() ) )
                return;
            _description.AppendFormat( "{0}:{1},", name, value );
        }
        #endregion
    }

    /// <summary>
    /// 以Guid 为标识的领域实体
    /// </summary>
    public abstract class EntityBase : EntityBase<Guid>
    {
        /// <summary>
        /// 初始化领域实体
        /// </summary>
        /// <param name="id">标识</param>
        protected EntityBase(Guid id) : base(id)
        {
        }
    }
}
