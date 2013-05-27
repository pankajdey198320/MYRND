using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecurityConfig
{
    public partial class ucMethodArgumentComparator : System.Web.UI.UserControl
    {
        List<Comparator> _tempObj = new List<Comparator>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCompAdd_Click(object sender, EventArgs e)
        {
            var paramType = Convert.ToInt32(ddlParamType.SelectedValue);
            int ParamIndex = 0;

            int.TryParse(txtCompIndex.Text, out ParamIndex);// Convert.ToInt32();
            addComparatorToSession(txtXompKey.Text, ParamIndex, paramType);
            bindComparator();
            txtCompIndex.Text = "";
            txtXompKey.Text = "";
            ddlParamType.SelectedIndex = 1;
        }

        private void bindComparator()
        {
            bindComparator(-1);
        }

        public void bindComparator(long pkId)
        {
            // resetComparator();
            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {
                var objComparators = (from v in l.L_SECU_METHOD_ARG_COMPARATOR
                                      // join k in l.L_SECU_MNU_OP_MAP on v.FK_MENU_OP_MAP_ID equals k.PK_ID
                                      where v.FK_METHOD_ID == pkId  // k.REFERANCE == selecteScreenn && k.OPERATION_MODE == OpMode
                                      select v).Distinct();
                foreach (L_SECU_METHOD_ARG_COMPARATOR comPobj in objComparators)
                {
                    addComparatorToSession(comPobj.PARAM_KEY, comPobj.PARAM_INDEX, comPobj.TYPE);
                }
                var comparator = getCurrentTempletMap();
                if (comparator != null)
                {
                    dtListCopm.DataSource = comparator;
                    dtListCopm.DataBind();
                }
            }
        }


        public void resetComparator()
        {
            var comparator = getCurrentTempletMap();
            if (comparator != null)
            {
                comparator.Clear();
            }
        }

        private void addComparatorToSession(string Key, int? index, int type)
        {
            var comparator = getCurrentTempletMap();

            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {

                //var OperationMenuMap = (from v in _tempObj where v.menuID == selectedMenu && v.OperationMode == OpMode select v).FirstOrDefault();
                if (comparator != null)
                {

                    var isExist = (from vObj in comparator
                                   where vObj.ParamKey == Key
                                       && vObj.ParamIndex == index
                                   select vObj).FirstOrDefault();
                    if (isExist == null)
                    {
                        comparator.Add(new Comparator()
                        {
                            ParamIndex = index,
                            ParamKey = Key,
                            ParamType = type

                        });
                    }
                }
            }
            //}
        }


        private List<Comparator> getCurrentTempletMap()
        {
            if (Session["TempComparator"] != null)
            {
                _tempObj = (List<Comparator>)Session["TempComparator"];

                //// var selectedMenu = string.IsNullOrWhiteSpace(hdnMenuID.Value) ? -1 : Convert.ToInt64(hdnMenuID.Value);
                //using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
                //{

                //    // var OperationMenuMap = (from v in _tempObj
                //    //                       where v.menuID == selectedMenu && v.OperationMode == OpMode
                //    //                     select v).FirstOrDefault();
                //    return _tempObj;
                //}
            }
            else
            {
                Session["TempComparator"] = _tempObj;
            }
            return _tempObj;

        }

        public void SaveComparator(long PkID)
        {
            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {
                foreach (Comparator cmprObjs in getCurrentTempletMap())
                {
                    var objCount = (from vCpObj in l.L_SECU_METHOD_ARG_COMPARATOR
                                    where vCpObj.FK_METHOD_ID == PkID
                                        && vCpObj.PARAM_KEY == cmprObjs.ParamKey && vCpObj.PARAM_INDEX == cmprObjs.ParamIndex
                                    select vCpObj).ToArray().Count();
                    if (objCount == 0)
                    {
                        l.AddToL_SECU_METHOD_ARG_COMPARATOR(new L_SECU_METHOD_ARG_COMPARATOR()
                        {
                            FK_METHOD_ID = PkID,
                            PARAM_INDEX = cmprObjs.ParamIndex,
                            PARAM_KEY = cmprObjs.ParamKey,
                            TYPE = cmprObjs.ParamType
                        });
                    }
                }
                l.SaveChanges();
            }

        }
    }
}