(function(f){var e=(f.browser.msie?"paste":"input")+".mask";var d=(window.orientation!=undefined);f.mask={definitions:{"9":"[0-9]",a:"[A-Za-z]","*":"[A-Za-z0-9]"}};f.fn.extend({caret:function(a,c){if(this.length==0){return}if(typeof a=="number"){c=(typeof c=="number")?c:a;return this.each(function(){if(this.setSelectionRange){this.focus();this.setSelectionRange(a,c)}else{if(this.createTextRange){var h=this.createTextRange();h.collapse(true);h.moveEnd("character",c);h.moveStart("character",a);h.select()}}})}else{if(this[0].setSelectionRange){a=this[0].selectionStart;c=this[0].selectionEnd}else{if(document.selection&&document.selection.createRange){var b=document.selection.createRange();a=0-b.duplicate().moveStart("character",-100000);c=a+b.text.length}}return{begin:a,end:c}}},unmask:function(){return this.trigger("unmask")},mask:function(n,b){if(!n&&this.length>0){var m=f(this[0]);var c=m.data("tests");return f.map(m.data("buffer"),function(g,h){return c[h]?g:null}).join("")}b=f.extend({placeholder:"_",completed:null},b);var o=f.mask.definitions;var c=[];var a=n.length;var l=null;var p=n.length;f.each(n.split(""),function(h,g){if(g=="?"){p--;a=h}else{if(o[g]){c.push(new RegExp(o[g]));if(l==null){l=c.length-1}}else{c.push(null)}}});return this.each(function(){var B=f(this);var i=f.map(n.split(""),function(r,q){if(r!="?"){return o[r]?b.placeholder:r}});var D=false;var z=B.val();B.data("buffer",i).data("tests",c);function C(q){while(++q<=p&&!c[q]){}return q}function j(r){while(!c[r]&&--r>=0){}for(var s=r;s<p;s++){if(c[s]){i[s]=b.placeholder;var q=C(s);if(q<p&&c[s].test(i[q])){i[s]=i[q]}else{break}}}g();B.caret(Math.max(l,r))}function y(u){for(var s=u,r=b.placeholder;s<p;s++){if(c[s]){var q=C(s);var t=i[s];i[s]=r;if(q<p&&c[q].test(t)){r=t}else{break}}}}function h(s){var r=f(this).caret();var q=s.keyCode;D=(q<16||(q>16&&q<32)||(q>32&&q<41));if((r.begin-r.end)!=0&&(!D||q==8||q==46)){x(r.begin,r.end)}if(q==8||q==46||(d&&q==127)){j(r.begin+(q==46?0:-1));return false}else{if(q==27){B.val(z);B.caret(0,k());return false}}}function A(r){if(D){D=false;return(r.keyCode==8)?false:null}r=r||window.event;var q=r.charCode||r.keyCode||r.which;var t=f(this).caret();if(r.ctrlKey||r.altKey||r.metaKey){return true}else{if((q>=32&&q<=125)||q>186){var s=C(t.begin-1);if(s<p){var v=String.fromCharCode(q);if(c[s].test(v)){y(s);i[s]=v;g();var u=C(s);f(this).caret(u);if(b.completed&&u==p){b.completed.call(B)}}}}}return false}function x(r,q){for(var s=r;s<q&&s<p;s++){if(c[s]){i[s]=b.placeholder}}}function g(){return B.val(i.join("")).val()}function k(v){var t=B.val();var u=-1;for(var r=0,q=0;r<p;r++){if(c[r]){i[r]=b.placeholder;while(q++<t.length){var s=t.charAt(q-1);if(c[r].test(s)){i[r]=s;u=r;break}}if(q>t.length){break}}else{if(i[r]==t[q]&&r!=a){q++;u=r}}}if(!v&&u+1<a){B.val("");x(0,p)}else{if(v||u+1>=a){g();if(!v){B.val(B.val().substring(0,u+1))}}}return(a?r:l)}if(!B.attr("readonly")){B.one("unmask",function(){B.unbind(".mask").removeData("buffer").removeData("tests")}).bind("focus.mask",function(){z=B.val();var q=k();g();setTimeout(function(){if(q==n.length){B.caret(0,q)}else{B.caret(q)}},0)}).bind("blur.mask",function(){k();if(B.val()!=z){B.change()}}).bind("keydown.mask",h).bind("keypress.mask",A).bind(e,function(){setTimeout(function(){B.caret(k(true))},0)})}k()})}})})(jQuery);