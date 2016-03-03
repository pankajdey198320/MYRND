using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecurityConfig
{
    public partial class TempletMenuMap : System.Web.UI.Page
    {
        List<TempeltMap> _tempObj;//= new List<TempeltMep>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["TempGrid"] = null;
            }
            else
            {
                var c = PlaceHolder1.Controls;
                if (sender is DropDownList)
                {
                    var Down = (DropDownList)sender;
                    ///  PopulateChiled(Convert.ToInt64( Down.SelectedValue));
                }
            }
        }

        protected void ddlScreen_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindSections();
        }

        protected void ddlSection_DataBound(object sender, EventArgs e)
        {
            BindActionMap();
        }

        protected void ddlScreen_DataBound(object sender, EventArgs e)
        {
            bindSections();
        }



        protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindActionMap();
        }

        private void bindSections()
        {
            var selecteScreenn = string.IsNullOrWhiteSpace(ddlScreen.SelectedValue) ? -1 : Convert.ToInt64(ddlScreen.SelectedValue);

            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {
                var Sections = (from v in l.L_SECU_CONFIG
                                //join k in l.L_SECU_ALL_METHODS on v.PK_ID equals k.FK_CONFIG_ID 
                                where v.ROW_STATUS == 1 &&
                                     v.FK_SCE_CONFIG_TYPE == 4 &&
                                     (from x in l.L_SECU_SECTION_OPERATION_MAP
                                      where x.FK_SCE_CONFIG_ID != v.PK_ID
                                      // //&& x.OPERATION_NAME == k.METHOD_NAME 
                                      select x).Count() > 0 &&
                                    v.FK_PK_PARENT_ID == selecteScreenn
                                select new
                                {
                                    v.PK_ID,
                                    v.NAME
                                }).Distinct();
                ddlSection.DataTextField = "NAME";
                ddlSection.DataValueField = "PK_ID";
                ddlSection.DataSource = Sections;
                ddlSection.DataBind();
            }
        }

        private void bindComparator()
        {
            var selecteScreenn = string.IsNullOrWhiteSpace(rdbAction.SelectedValue) ? -1 : Convert.ToInt64(rdbAction.SelectedValue);
            //var OpMode = Convert.ToInt64(RadioButtonList2.SelectedValue);
            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {
                var objComparators = (from v in l.L_SECU_METHOD_ARG_COMPARATOR
                                       join k in l.L_SECU_ALL_METHODS on v.FK_METHOD_ID equals k.PK_ID
                                       join objSecMethod in l.L_SECU_SECTION_OPERATION_MAP on k.METHOD_NAME equals objSecMethod.OPERATION_NAME
                                      where objSecMethod.PK_ID == selecteScreenn //&& k.OPERATION_MODE == OpMode
                                      select v).Distinct();
                foreach (L_SECU_METHOD_ARG_COMPARATOR comPobj in objComparators)
                {
                    addComparatorToSession(comPobj.PK_ID, string.Empty);
                }
                var OperationMenuMap = getCurrentTempletMap();
                //if (OperationMenuMap != null)
                //{
                dtListCopm.DataSource = objComparators;
                dtListCopm.DataBind();
                // }
            }
        }

        private void BindActionMap()
        {
            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {
                var selectedSection = string.IsNullOrWhiteSpace(ddlSection.SelectedValue) ? -1 : Convert.ToInt64(ddlSection.SelectedValue);
                var Sections = (from v in l.L_SECU_SECTION_OPERATION_MAP
                                join vMap in l.L_SECU_ALL_METHODS on v.FK_METHOD_ID equals vMap.PK_ID
                                join
                                    ac in l.l_SECU_OPERATION_ACTION on v.FK_ACTION_ID equals ac.PK_ID
                                where v.FK_SCE_CONFIG_ID == selectedSection
                                select new
                                {
                                    v.PK_ID,
                                 ACTION_NAME=   ac.ACTION_NAME +"("+ vMap.METHOD_NAME+")"
                                });
                rdbAction.DataTextField = "ACTION_NAME";
                rdbAction.DataValueField = "PK_ID";
                rdbAction.DataSource = Sections;
                rdbAction.DataBind();
            }
        }

        protected void ddlMenu_DataBound(object sender, EventArgs e)
        {
            var selectedValu = ((DropDownList)sender).SelectedValue;
            var select = string.IsNullOrWhiteSpace(selectedValu) ? -1 : Convert.ToInt64(selectedValu);
            //if (select > 0)
            //    PopulateChiled(select);
        }
        private void PopulateChiled(long parentID, int level)
        {
            var chld = hasChild(parentID);
            if (chld != null)
            {
                if (level == 1)
                {
                    ddlMenu.DataSource = chld;
                    ddlMenu.DataBind();
                }
                else if (level == 2)
                {
                    ddlMenu_1.DataSource = chld;
                    ddlMenu_1.DataBind();
                }
                else if (level == 3)
                {
                    ddlMenu_2.DataSource = chld;
                    ddlMenu_2.DataBind();
                }
                else if (level == 4)
                {
                    ddlMenu_3.DataSource = chld;
                    ddlMenu_3.DataBind();
                }
                hdnLevel.Value = level.ToString();
            }
        }


        private List<L_V_UTILITY_MENU> hasChild(long ParentID)
        {
            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {
                var Op = (from v in l.L_V_UTILITY_MENU where v.FK_PARENT_ID == ParentID select v).ToList();
                if (Op.Count == 0)
                    return null;
                else
                {
                    Op.Insert(0, new L_V_UTILITY_MENU() { PK_MENU_ID = -200, MENU_NAME = "---select----" });
                    return Op;
                }
            }

        }

        protected void ddlMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //var selectedName =Convert.ToInt64( ddlMenu.SelectedValue);
            var selectedName = string.IsNullOrWhiteSpace(hdnMenuID.Value) ? -1 : Convert.ToInt64(hdnMenuID.Value);
            if (selectedName != -1)
            {
                var selectedOp = Convert.ToInt64(rdbAction.SelectedValue);
                var SelectedMode = Convert.ToInt32((Mode)Enum.Parse(typeof(Mode), RadioButtonList2.SelectedItem.Text));
                if (Session["TempGrid"] == null)
                    _tempObj = new List<TempeltMap>();
                else
                    _tempObj = (List<TempeltMap>)Session["TempGrid"];
                var itm = (from v in _tempObj
                           where v.menuID == selectedName && v.OperationMapID == selectedOp && v.OperationMode == SelectedMode
                           select v).FirstOrDefault();
                if (itm == null)
                {
                    var ObjItem = new TempeltMap()
                    {
                        menuID = selectedName,
                        OperationMapID = selectedOp,
                        OperationMode = SelectedMode
                    };
                    _tempObj.Add(ObjItem);

                    foreach (DataListItem dataItem in dtListCopm.Items)
                    {
                        var hdPkID = Convert.ToInt64(((HiddenField)dataItem.FindControl("hdnComparatorID")).Value);
                        TextBox txtVal = (TextBox)dataItem.FindControl("txtComparatorValue");
                        //var HasItem = (from vCompVal in l.L_SECU_COMPARATOR_VALUE
                        //               where
                        //                   vCompVal.PARAM_VALUE == txtVal.Text && vCompVal.FK_COMPARATOR_ID == hdPkID
                        //                   && vCompVal.FK_MENU_MAP_ID == pk_id
                        //               select vCompVal).FirstOrDefault();
                        if (!string.IsNullOrWhiteSpace(txtVal.Text))
                        {
                            ObjItem.comparator.Add(new ComparatorValue()
                            {
                                ComparatorID = hdPkID,
                                ParamValue = txtVal.Text

                            });
                        }
                    }
                }
                Session["TempGrid"] = _tempObj;
                BindGrid();

            }
        }
        private void BindGrid()
        {
            if (Session["TempGrid"] != null)
            {
                _tempObj = (List<TempeltMap>)Session["TempGrid"];
                var selectedMenu = string.IsNullOrWhiteSpace(hdnMenuID.Value) ? -1 : Convert.ToInt64(hdnMenuID.Value);
                using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
                {
                    var menuName = (from v in _tempObj where v.menuID == selectedMenu select new { v.menuID, v.OperationMode}).Distinct();

                    var vMenu = new List<GridL>();
                    foreach (var menu in menuName)
                    {
                        var Items = (from s in _tempObj
                                     join vk in l.L_SECU_SECTION_OPERATION_MAP
                                     on s.OperationMapID equals vk.PK_ID
                                     join kl in l.L_SECU_CONFIG on vk.FK_SCE_CONFIG_ID equals kl.PK_ID
                                     join ac in l.l_SECU_OPERATION_ACTION on vk.FK_ACTION_ID equals ac.PK_ID

                                     where s.menuID == menu.menuID && s.OperationMode == menu.OperationMode                                     
                                     select
                                         kl.NAME +"("+vk.OPERATION_NAME+")"
                                    ).ToArray();
                        // var CommaSaperatedString =Items.Aggregate((a,b)=> a+","+b);
                        vMenu.Add(new GridL()
                        {
                            MenuName = (from vx in l.L_V_UTILITY_MENU where vx.PK_MENU_ID == menu.menuID select vx.MENU_NAME).FirstOrDefault(),
                            AssignedAction = Items.Aggregate((a, b) => a + ", " + b) ,
                            OperationMode = Enum.GetName(typeof(Mode), menu.OperationMode)
                            
                        });
                    }
                    grvTemplet.DataSource = vMenu;
                    grvTemplet.DataBind();
                }
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {

            if (Session["TempGrid"] != null)
            {
                _tempObj = (List<TempeltMap>)Session["TempGrid"];
                using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
                {
                    long pk_id;

                    var AddObj = (from vObj in _tempObj
                                  select new L_SECU_MNU_OP_MAP()
                                  {
                                      REFERANCE = vObj.menuID,
                                      FK_OPERATION_MAP_ID = vObj.OperationMapID,
                                      OPERATION_MODE = Convert.ToInt32(vObj.OperationMode)

                                  });
                    foreach (TempeltMap itm in _tempObj)
                    {
                        var IsExist = (from v in l.L_SECU_MNU_OP_MAP
                                       where
                                           v.OPERATION_MODE == itm.OperationMode &&
                                           v.FK_OPERATION_MAP_ID == itm.OperationMapID &&
                                           v.REFERANCE == itm.menuID
                                       select v

                                          ).FirstOrDefault();
                        if (IsExist == null)
                        {
                            L_SECU_MNU_OP_MAP objAddMap = new L_SECU_MNU_OP_MAP()
                            {
                                REFERANCE = itm.menuID,
                                FK_OPERATION_MAP_ID = itm.OperationMapID,
                                OPERATION_MODE = Convert.ToInt32(itm.OperationMode)
                            };
                            l.AddToL_SECU_MNU_OP_MAP(objAddMap);
                            l.SaveChanges();
                            pk_id = objAddMap.PK_ID;
                        }
                        else
                        {
                            pk_id = IsExist.PK_ID;
                        }
                        foreach (ComparatorValue cmprObjs in itm.comparator)//DataListItem dataItem in dtListCopm.Items)
                        {
                            //var hdPkID = Convert.ToInt64(((HiddenField)dataItem.FindControl("hdnComparatorID")).Value);
                            //TextBox txtVal = (TextBox)dataItem.FindControl("txtComparatorValue");
                            var HasItem = (from vCompVal in l.L_SECU_COMPARATOR_VALUE
                                           where
                                               vCompVal.PARAM_VALUE == cmprObjs.ParamValue && vCompVal.FK_COMPARATOR_ID == cmprObjs.ComparatorID
                                               && vCompVal.FK_MENU_MAP_ID == pk_id
                                           select vCompVal).FirstOrDefault();
                            if (HasItem == null&& !string.IsNullOrWhiteSpace(cmprObjs.ParamValue))
                            {
                                l.AddToL_SECU_COMPARATOR_VALUE(new L_SECU_COMPARATOR_VALUE()
                                {
                                    FK_COMPARATOR_ID = cmprObjs.ComparatorID,
                                    FK_MENU_MAP_ID = pk_id,
                                    PARAM_VALUE = cmprObjs.ParamValue 
                                });
                            }
                        }
                        //foreach (Comparator cmprObjs in itm.comparator)
                        //{
                        //    l.AddToL_SECU_MENU_MAP_COMPARATOR(new L_SECU_MENU_MAP_COMPARATOR()
                        //    {
                        //        FK_MENU_OP_MAP_ID = pk_id,
                        //        PARAM_INDEX = cmprObjs.ParamIndex,
                        //        PARAM_KEY = cmprObjs.ParamKey,
                        //        PARAM_VALUE = cmprObjs.ParamValue,
                        //        TYPE = cmprObjs.ParamType
                        //    });
                        //}
                    }
                    l.SaveChanges();
                    Session["TempGrid"] = null;
                }
            }
            BindGrid();
        }

        protected void rLstParentMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMenu.Items.Clear();
            ddlMenu_1.Items.Clear();
            ddlMenu_2.Items.Clear();

           PopulateChiled(Convert.ToInt64(rLstParentMenu.SelectedValue), 1);
        }

        protected void Menu_selected(object sender, EventArgs e)
        {

            // hdnLevel.Value = "-100";
            var selectedValu = ((DropDownList)sender);
            //  var select = string.IsNullOrWhiteSpace(selectedValu) ? -1 : Convert.ToInt64(selectedValu);

            if (selectedValu.ID == "ddlMenu")
            {
                hdnMenuID.Value = ddlMenu.SelectedValue;
                ddlMenu_1.Items.Clear();

                PopulateChiled(Convert.ToInt64(ddlMenu.SelectedValue), 2);
            }
            else if (selectedValu.ID == "ddlMenu_1")
            {
                hdnMenuID.Value = ddlMenu_1.SelectedValue;
                ddlMenu_2.Items.Clear();
                PopulateChiled(Convert.ToInt64(ddlMenu_1.SelectedValue), 3);
            }
            else if (selectedValu.ID == "ddlMenu_2")
            {
                hdnMenuID.Value = ddlMenu_2.SelectedValue;
                // PopulateChiled(Convert.ToInt64(ddlMenu_2.SelectedValue), 4);
            }


            //if (select > 0)
            //    PopulateChiled(select);
            if (Session["TempGrid"] == null)
                using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
                {

                    _tempObj = (from v in l.L_SECU_MNU_OP_MAP
                                select new TempeltMap()
                                {
                                    menuID = v.REFERANCE,
                                    OperationMapID = v.FK_OPERATION_MAP_ID,
                                    OperationMode = (int)v.OPERATION_MODE

                                }).ToList();
                    Session["TempGrid"] = _tempObj;

                }
            BindGrid();
            bindComparator();
        }

        private TempeltMap getCurrentTempletMap()
        {
            if (Session["TempGrid"] != null)
            {
                _tempObj = (List<TempeltMap>)Session["TempGrid"];
                var OpMode = Convert.ToInt64(RadioButtonList2.SelectedValue);
                var selectedMenu = string.IsNullOrWhiteSpace(hdnMenuID.Value) ? -1 : Convert.ToInt64(hdnMenuID.Value);
                using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
                {

                    var OperationMenuMap = (from v in _tempObj
                                            where v.menuID == selectedMenu && v.OperationMode == OpMode
                                            select v).FirstOrDefault();
                    return OperationMenuMap;
                }
            }
            else
            {
                return null;
            }
        }
        private void addComparatorToSession(long ID, string value)
        {
            var OperationMenuMap = getCurrentTempletMap();

            //if (Session["TempGrid"] != null)
            //{
            //_tempObj = (List<TempeltMap>)Session["TempGrid"];
            //var OpMode = Convert.ToInt64(RadioButtonList2.SelectedValue);
            //var selectedMenu = string.IsNullOrWhiteSpace(hdnMenuID.Value) ? -1 : Convert.ToInt64(hdnMenuID.Value);
            using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
            {

                //var OperationMenuMap = (from v in _tempObj where v.menuID == selectedMenu && v.OperationMode == OpMode select v).FirstOrDefault();
                if (OperationMenuMap != null)
                {

                    var isExist = (from vObj in OperationMenuMap.comparator
                                   where vObj.ComparatorID == ID
                                       && vObj.ParamValue == value
                                   select vObj).FirstOrDefault();
                    if (isExist == null)
                    {
                        OperationMenuMap.comparator.Add(new ComparatorValue()
                        {
                            ComparatorID = ID,
                            ParamValue = value


                        });
                    }
                }
            }
        }

        protected void btnCompAdd_Click(object sender, EventArgs e)
        {
            //var paramType = Convert.ToInt32(ddlParamType.SelectedValue);
            //int ParamIndex = 0;

            //int.TryParse(txtCompIndex.Text, out ParamIndex);// Convert.ToInt32();
            //addComparatorToSession(txtXompKey.Text, txtCompValu.Text, ParamIndex, paramType);
            //bindComparator();
            //txtCompIndex.Text = "";
            //txtCompValu.Text = "";
            //txtXompKey.Text = "";
            //ddlParamType.SelectedIndex = 1;
        }

        protected void rdbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindComparator();
        }

        protected void grvTemplet_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Session["TempGrid"] = null;
            if (Session["TempGrid"] == null)
                using (Medappz2_LiveEntities l = new Medappz2_LiveEntities())
                {

                    _tempObj = (from v in l.L_SECU_MNU_OP_MAP
                                select new TempeltMap()
                                {
                                    menuID = v.REFERANCE,
                                    OperationMapID = v.FK_OPERATION_MAP_ID,
                                    OperationMode = (int)v.OPERATION_MODE

                                }).ToList();
                    Session["TempGrid"] = _tempObj;

                }
           // ((List<TempeltMap>)Session["TempGrid"]).Clear();
            BindGrid();
        }

        

    }
    class GridL
    {
        public string MenuName { set; get; }
        public string AssignedAction { set; get; }
        public string OperationMode { set; get; }
        public long PK_ID { set; get; }
    }
    class TempeltMap
    {
        List<ComparatorValue> _Cmpr = new List<ComparatorValue>();
        public long menuID { set; get; }
        public long OperationMapID { set; get; }
        public Int32 OperationMode { set; get; }
        public List<ComparatorValue> comparator { get { return _Cmpr; } }
    }
    class Comparator
    {
        public string ParamKey { set; get; }
        public string ParamValue { set; get; }
        public int? ParamIndex { set; get; }
        public int ParamType { set; get; }
    }
    class ComparatorValue
    {
        public long ComparatorID { set; get; }
        public long MenuMapID { set; get; }
        public string ParamValue { set; get; }

    }
    enum Mode
    {
        Enabled = 1, ReadOnly = 2
    }
}