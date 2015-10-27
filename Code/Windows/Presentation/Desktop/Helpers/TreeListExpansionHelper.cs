using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;

namespace HCMIS.Desktop.Helpers
{
    public class TreeListOperationCollapseExpandToLevel : TreeListOperationCollapseExpand
    {
        private int level;
        public TreeListOperationCollapseExpandToLevel(bool expand, int level) : base(expand) { this.level = level; }
        public override bool NeedsVisitChildren(TreeListNode node) { return node.Level < level; }
    }
}
