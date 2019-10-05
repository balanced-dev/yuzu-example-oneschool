using AutoMapper;
using YuzuDelivery.Umbraco.Blocks;
using YuzuDelivery.Umbraco.Forms;
using YuzuDelivery.Umbraco.Grid;
using OneSchool.Core.UmbracoModels;
//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v10.0.23.0 (Newtonsoft.Json v9.0.0.1) (http://NJsonSchema.org)
// </auto-generated>
//----------------------

namespace OneSchool.Core.ViewModels
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.23.0 (Newtonsoft.Json v9.0.0.1)")]
    public partial class vmPage_Course 
    {
        [Newtonsoft.Json.JsonProperty("header", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public vmBlock_PageHeader Header { get; set; }
    
        [Newtonsoft.Json.JsonProperty("title", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public vmBlock_CourseTitle Title { get; set; }
    
        [Newtonsoft.Json.JsonProperty("content", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public vmBlock_DataGridRowsColumns Content { get; set; }
    
        [Newtonsoft.Json.JsonProperty("teacher", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public vmBlock_CourseTeacher Teacher { get; set; }
    
        [Newtonsoft.Json.JsonProperty("comments", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public vmBlock_Comments Comments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("courses", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public vmBlock_CourseList Courses { get; set; }
    
    
    }
}