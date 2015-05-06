using System.ComponentModel.DataAnnotations;

namespace Util.Validations.EntLib.Tests.Samples
{
    /// <summary>
    /// 测试实体
    /// </summary>
    public class TestModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "姓名不能为空")]
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(5, ErrorMessage = "描述不能超过5位")]
        public string Description { get; set; }
    }
}