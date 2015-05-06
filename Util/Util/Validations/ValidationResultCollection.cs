using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Util.Validations
{
    public class ValidationResultCollection:IEnumerable<ValidationResult>
    {
        /// <summary>
        /// 初始化验证结果集合
        /// </summary>
        public ValidationResultCollection()
        {
            _results=new List<ValidationResult>();
        }

        /// <summary>
        /// 验证结果集合
        /// </summary>
        private readonly List<ValidationResult> _results;

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid {
            get { return _results.Count == 0; }
        }

        /// <summary>
        /// 验证结果个数
        /// </summary>
        public int Count {
            get { return _results.Count; }
        }

        /// <summary>
        /// 添加验证结果
        /// </summary>
        /// <param name="result">验证结果</param>
        public void Add(ValidationResult result)
        {
            if (result!=null)
                _results.Add(result);
        }

        /// <summary>
        /// 添加验证结果集合
        /// </summary>
        /// <param name="results">验证结果集合</param>
        public void AddResults(IEnumerable<ValidationResult> results)
        {
            if(results!=null)
                _results.AddRange(results);
        }

        /// <summary>
        /// 获取迭代器
        /// </summary>
        public IEnumerator<ValidationResult> GetEnumerator()
        {
            return _results.GetEnumerator();
        }

        /// <summary>
        /// 获取迭代器
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _results.GetEnumerator();
        }
    }
}
