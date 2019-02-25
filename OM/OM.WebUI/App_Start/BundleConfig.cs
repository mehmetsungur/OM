using System.Web.Optimization;

namespace OM.WebUI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //----------------------- CSS ---------------------------//
            bundles.Add(new StyleBundle("~/css/Default").Include(
                "~/Areas/DashBoard/Content/css/Custom/imgStyle.css",
                "~/Areas/DashBoard/Content/css/Default/fullcalendar.min.css",
                "~/Areas/DashBoard/Content/css/Default/custombox.min.css",
                "~/Areas/DashBoard/Content/css/Default/sweetalert2.min.css",
                "~/Areas/DashBoard/Content/css/Default/bootstrap.min.css",
                "~/Areas/DashBoard/Content/css/Default/icons.min.css",
                "~/Areas/DashBoard/Content/css/Default/app.min.css"));

            bundles.Add(new StyleBundle("~/css/Datatables").Include(
                "~/Areas/DashBoard/Content/css/Default/dataTables.bootstrap4.css",
                "~/Areas/DashBoard/Content/css/Default/responsive.bootstrap4.css",
                "~/Areas/DashBoard/Content/css/Default/buttons.bootstrap4.css",
                "~/Areas/DashBoard/Content/css/Default/select.bootstrap4.css"));

            bundles.Add(new StyleBundle("~/css/Front").Include(
                "~/Content/Custom/bootstrap/css/bootstrap.min.css",
                "~/Content/Custom/fontawesome-free/css/all.min.css",
                "~/Content/Other/css/agency.min.css",
                "~/sss/sss.css",
                "~/sss/estilos.css"));

            bundles.Add(new StyleBundle("~/css/Custom/LogX").Include(
                "~/Areas/DashBoard/Content/css/Default/ladda-themeless.min.css",
                "~/Areas/DashBoard/Content/css/Default/sweetalert2.min.css"));

            //----------------------- JS ---------------------------//
            bundles.Add(new ScriptBundle("~/js/Default").Include(
                "~/Areas/DashBoard/Content/js/Default/vendor.min.js",
                "~/Areas/DashBoard/Content/js/Default/custombox.min.js",
                "~/Areas/DashBoard/Content/js/Default/jquery.sparkline.min.js",
                "~/Areas/DashBoard/Content/js/Default/jquery.dataTables.js",
                "~/Areas/DashBoard/Content/js/Default/dataTables.bootstrap4.js",
                "~/Areas/DashBoard/Content/js/Default/dataTables.responsive.min.js",
                "~/Areas/DashBoard/Content/js/Default/responsive.bootstrap4.min.js",
                "~/Areas/DashBoard/Content/js/Default/dataTables.buttons.min.js",
                "~/Areas/DashBoard/Content/js/Default/buttons.bootstrap4.min.js",
                "~/Areas/DashBoard/Content/js/Default/buttons.html5.min.js",
                "~/Areas/DashBoard/Content/js/Default/buttons.flash.min.js",
                "~/Areas/DashBoard/Content/js/Default/buttons.print.min.js",
                "~/Areas/DashBoard/Content/js/Default/dataTables.keyTable.min.js",
                "~/Areas/DashBoard/Content/js/Default/dataTables.select.min.js",
                "~/Areas/DashBoard/Content/js/Default/pdfmake.min.js",
                "~/Areas/DashBoard/Content/js/Default/vfs_fonts.js",
                "~/Areas/DashBoard/Content/js/Default/crm-opportunities.init.js",
                "~/Areas/DashBoard/Content/js/Default/datatables.init.js",
                "~/Areas/DashBoard/Content/js/Default/app.min.js",
                "~/Areas/DashBoard/Content/js/Default/raphael.min.js",
                "~/Areas/DashBoard/Content/js/Default/morris.min.js",
                "~/Areas/DashBoard/Content/js/Default/dashboard-4.init.js"));

            bundles.Add(new ScriptBundle("~/js/Custom/Create").Include(
                "~/Areas/DashBoard/Content/js/Default/sweetalert2.min.js",
                "~/Areas/DashBoard/Content/js/Custom/CreateMeet.js",
                "~/Areas/DashBoard/Content/js/Custom/CreateCompany.js",
                "~/Areas/DashBoard/Content/js/Custom/CreateProduct.js",
                "~/Areas/DashBoard/Content/js/Custom/CreateProject.js",
                "~/Areas/DashBoard/Content/js/Custom/CreatePersonnel.js",
                "~/Areas/DashBoard/Content/js/Custom/CreateMachine.js",
                "~/Areas/DashBoard/Content/js/Custom/CreateTask.js",
                "~/Areas/DashBoard/Content/js/Custom/CreateCustomer.js"));

            bundles.Add(new ScriptBundle("~/js/Agenda").Include(
                "~/Areas/DashBoard/Content/js/Default/moment.min.js",
                "~/Areas/DashBoard/Content/js/Default/jquery-ui.min.js",
                "~/Areas/DashBoard/Content/js/Default/fullcalendar.min.js",
                "~/Areas/DashBoard/Content/js/Default/calendar.init.js",
                "~/Areas/DashBoard/Content/js/Default/tr.js"));

            bundles.Add(new ScriptBundle("~/js/Custom/LogX").Include(
            "~/Areas/DashBoard/Content/js/Default/spin.js",
            "~/Areas/DashBoard/Content/js/Default/ladda.js",
            "~/Areas/DashBoard/Content/js/Default/loading-btn.init.js",
            "~/Areas/DashBoard/Content/js/Default/jquery.validate.min.js",
            "~/Areas/DashBoard/Content/js/Default/jquery-3.3.1.min.js",
            "~/Areas/DashBoard/Content/js/Default/sweetalert2.min.js",
            "~/Areas/DashBoard/Content/js/Custom/LogIn.js",
            "~/Areas/DashBoard/Content/js/Custom/LogLock.js"));

            bundles.Add(new ScriptBundle("~/js/Front").Include(
                "~/Content/Custom/jquery/jquery.min.js",
                "~/Content/Custom/bootstrap/js/bootstrap.bundle.min.js",
                "~/Content/Custom/jquery-easing/jquery.easing.min.js",
                "~/Content/Other/js/jqBootstrapValidation.js",
                "~/Content/Other/js/contact_me.js",
                "~/Content/Other/js/agency.min.js"));
        }
    }
}