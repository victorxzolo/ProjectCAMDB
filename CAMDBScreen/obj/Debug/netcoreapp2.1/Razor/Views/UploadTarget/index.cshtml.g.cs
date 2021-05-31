#pragma checksum "C:\Users\User\Documents\ProjectCAMDB\CAMDBScreen\Views\UploadTarget\index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0639b3496a0c2893b777d64f0079b2dec0dad097"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UploadTarget_index), @"mvc.1.0.view", @"/Views/UploadTarget/index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/UploadTarget/index.cshtml", typeof(AspNetCore.Views_UploadTarget_index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\User\Documents\ProjectCAMDB\CAMDBScreen\Views\_ViewImports.cshtml"
using CAMDBScreen;

#line default
#line hidden
#line 2 "C:\Users\User\Documents\ProjectCAMDB\CAMDBScreen\Views\_ViewImports.cshtml"
using CAMDBScreen.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0639b3496a0c2893b777d64f0079b2dec0dad097", @"/Views/UploadTarget/index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2299f10f52c24c196c874ea3770c314b8329939", @"/Views/_ViewImports.cshtml")]
    public class Views_UploadTarget_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Export", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\User\Documents\ProjectCAMDB\CAMDBScreen\Views\UploadTarget\index.cshtml"
  
    ViewBag.Title = "Register Campaign Code";


#line default
#line hidden
            BeginContext(154, 6409, true);
            WriteLiteral(@"<script type=""text/javascript"">
    $(document).ready(function () {

        let percentValue = 0,
            progressBar = $('.progress-bar');

        function startBar() {

            if (percentValue < 100) {
                percentValue += 1;
                progressBar.css(""width"", percentValue + ""%"").html(percentValue + ""%"");

            } else {
                clearInterval(timer);
            }
        }

        

        $('#btnshowdata').on('click', function () {

            var start_time = new Date().getTime();
            var fileExtension = ['xls', 'xlsx'];
            var filename = $('#fileupload').val();
            if (filename.length == 0) {
                alert(""Please select a file."");
                return false;
            }
            else {
                var extension = filename.replace(/^.*\./, '');
                if ($.inArray(extension, fileExtension) == -1) {
                    alert(""Please select only excel files."");
               ");
            WriteLiteral(@"     return false;
                }
            }

            var fdata = new FormData();
            var fileUpload = $(""#fileupload"").get(0);
            var files = fileUpload.files;
            fdata.append(files[0].name, files[0]);
            $.ajax({
                type: ""POST"",
                url: ""/UploadTarget/Showdata"",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader(""XSRF-TOKEN"",
                        $('input:hidden[name=""__RequestVerificationToken""]').val());

                    timer = setInterval(startBar, 500);
                    $("".progress"").show();


                    //start_time = new Date().getTime();
                },
                data: fdata,
                contentType: false,
                processData: false,
                success: function (response) {
                    if (response.length == 0)
                        alert('Some error occured while uploading');
                    else {


  ");
            WriteLiteral(@"                      var table = $(""#dataTable"").DataTable();


                        var ajaxTime = new Date().getTime();
                        var totalTime = ajaxTime - start_time;

                        if (percentValue < 100) percentValue = 99;
                        console.log(getdatetime(totalTime));

                        $(""#cardshowdata"").show();
                        setTimeout(() => { $("".progress"").hide(100); }, 1000);

                    }
                },
                error: function (e) {

                }
            });

        })
        $('#btnvalidatedata').on('click', function () {

            
            var start_time = new Date().getTime();
            var fileExtension = ['xls', 'xlsx'];
            var filename = $('#fileupload').val();
            if (filename.length == 0) {
                alert(""Please select a file."");
                return false;
            }
            else {
                var extension = filename.repl");
            WriteLiteral(@"ace(/^.*\./, '');
                if ($.inArray(extension, fileExtension) == -1) {
                    alert(""Please select only excel files."");
                    return false;
                }
            }

            var fdata = new FormData();
            var fileUpload = $(""#fileupload"").get(0);
            var files = fileUpload.files;
            fdata.append(files[0].name, files[0]);
            $.ajax({
                type: ""POST"",
                url: ""/UploadTarget/Validatedata"",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader(""XSRF-TOKEN"",
                        $('input:hidden[name=""__RequestVerificationToken""]').val());

                    timer = setInterval(startBar, 500);
                    $("".progress"").show();


                    //start_time = new Date().getTime();
                },
                data: fdata,
                contentType: false,
                processData: false,
                success: functio");
            WriteLiteral(@"n (response) {
                    if (response.length == 0)
                        alert('Some error occured while uploading');
                    else {

                        

                        //--
                        var table = $(""#dataTable"").DataTable();
                        table.rows.add($(response)).draw();
                        var ajaxTime = new Date().getTime();
                        var totalTime = ajaxTime - start_time;

                        if (percentValue < 100) percentValue = 99;
                        console.log(getdatetime(totalTime));

                        $(""#cardshowdata"").show();
                        setTimeout(() => { $("".progress"").hide(100); }, 1000);

                    }
                },
                error: function (e) {

                }
            });

        })

    });



    $(function () {
        $('#btnExport').on('click', function () {
            var fileExtension = ['xls', 'xlsx'];
         ");
            WriteLiteral(@"   var filename = $('#fileupload').val();
            if (filename.length == 0) {
                alert(""Please select a file then Import"");
                return false;
            }
        });
    });

    function getdatetime(d) {
        var Ms = null;
        var diffMs = d; // milliseconds between now & Christmas
        var diffDays = Math.floor(diffMs / 86400000); // days
        var diffHrs = Math.floor((diffMs % 86400000) / 3600000); // hours
        var diffMins = Math.round(((diffMs % 86400000) % 3600000) / 60000);
        var diffSecs = Math.round((((diffMs % 86400000) % 3600000) % 60000) / 1000); // seconds
        return Ms = diffMins + "":"" + diffSecs;
    }


</script>
<style>
    #error {
        color: red;
    }
    /* .progress:hover {
        display: none;
    }*/
    /*.progress {
        display: flex;
        height: .25rem;
    }
    .bg-success {
        background-color: #1eb349 !important;
    }*/
</style>
<nav style=""--bs-breadcrumb-divider: '");
            WriteLiteral(@">>';"" aria-label=""breadcrumb"">
    <ol class=""breadcrumb"">
        <li class=""breadcrumb-item active"">
            Home
        </li>
        <li class=""breadcrumb-item active"" aria-current=""page"">
            Upload Target
        </li>
    </ol>
</nav>
");
            EndContext();
            BeginContext(6563, 2418, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "590d43aac4e343c78651bf236b27cf17", async() => {
                BeginContext(6611, 483, true);
                WriteLiteral(@"
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-4"">
                <input type=""file"" id=""fileupload"" name=""files"" class=""form-control"" />
            </div>
            <div class=""col-md-3"">
                <input type=""button"" name=""Show Data"" value=""ShowData"" id=""btnshowdata"" class=""btn btn-primary"" />
                <input type=""button"" name=""Validate Data"" value=""validatedata"" id=""btnvalidatedata"" class=""btn btn-primary"" />
");
                EndContext();
                BeginContext(7207, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(7293, 22, true);
                WriteLiteral("            </div>\r\n\r\n");
                EndContext();
                BeginContext(7551, 403, true);
                WriteLiteral(@"        </div>
        <div class=""row"">
            <div class=""col-md-4"">

            </div>
        </div>
        <div class=""clearfix"">&nbsp;</div>
        <div class=""row"">

        </div>
        <div class=""card shadow mb-4"">
            <div class=""progress"" style=""display:none"">
                <div class=""progress-bar bg-success"" role=""progressbar""></div>
            </div>
");
                EndContext();
                BeginContext(8124, 850, true);
                WriteLiteral(@"            <div class=""card-body"" id=""cardshowdata"" style=""display:none"">
                <div class=""table-responsive"" style=""color:darkslateblue"">
                    <table class='table table-bordered' id='dataTable' width='100%' cellspacing='0'>
                        <thead>
                            <tr>
                                <th>Seq.</th>
                                <th>CS No.</th>
                                <th>Contract No.</th>
                                <th>Campaign Code</th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <!-- Bootstrap core JavaScript-->
        <!-- Page level plugins -->

    </div>

");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(8981, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(9191, 2, true);
            WriteLiteral("\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
