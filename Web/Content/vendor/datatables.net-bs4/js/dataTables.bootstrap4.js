!function(t){"function"==typeof define&&define.amd?define(["jquery","datatables.net"],function(e){return t(e,window,document)}):"object"==typeof exports?module.exports=function(e,a){return e=e||window,a&&a.fn.dataTable||(a=require("datatables.net")(e,a).$),t(a,e,e.document)}:t(jQuery,window,document)}(function(h,e,s,n){"use strict";var o=h.fn.dataTable;return h.extend(!0,o.defaults,{dom:"<'row'<'col-sm-12 col-md-6'l><'col-sm-12 col-md-6'f>><'row'<'col-sm-12'tr>><'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",renderer:"bootstrap"}),h.extend(o.ext.classes,{sWrapper:"dataTables_wrapper dt-bootstrap4",sFilterInput:"form-control form-control-sm",sLengthSelect:"custom-select custom-select-sm form-control form-control-sm",sProcessing:"dataTables_processing card",sPageButton:"paginate_button page-item"}),o.ext.renderer.pageButton.bootstrap=function(d,e,i,a,l,c){var u,p,t,f=new o.Api(d),m=d.oClasses,b=d.oLanguage.oPaginate,g=d.oLanguage.oAria.paginate||{},x=0,w=function(e,a){function t(e){e.preventDefault(),h(e.currentTarget).hasClass("disabled")||f.page()==e.data.action||f.page(e.data.action).draw("page")}var s,n,o,r;for(s=0,n=a.length;s<n;s++)if(r=a[s],h.isArray(r))w(e,r);else{switch(p=u="",r){case"ellipsis":u="&#x2026;",p="disabled";break;case"first":u=b.sFirst,p=r+(0<l?"":" disabled");break;case"previous":u=b.sPrevious,p=r+(0<l?"":" disabled");break;case"next":u=b.sNext,p=r+(l<c-1?"":" disabled");break;case"last":u=b.sLast,p=r+(l<c-1?"":" disabled");break;default:u=r+1,p=l===r?"active":""}u&&(o=h("<li>",{class:m.sPageButton+" "+p,id:0===i&&"string"==typeof r?d.sTableId+"_"+r:null}).append(h("<a>",{href:"#","aria-controls":d.sTableId,"aria-label":g[r],"data-dt-idx":x,tabindex:d.iTabIndex,class:"page-link"}).html(u)).appendTo(e),d.oApi._fnBindAction(o,{action:r},t),x++)}};try{t=h(e).find(s.activeElement).data("dt-idx")}catch(e){}w(h(e).empty().html('<ul class="pagination"/>').children("ul"),a),t!==n&&h(e).find("[data-dt-idx="+t+"]").focus()},o});