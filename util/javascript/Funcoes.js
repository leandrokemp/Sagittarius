/*************************
*      Menu Jquery      *
*************************/

/* SlideShow */
function slideShow(slide, btnprox, btnant) {
    $(slide).SlideShow({
        visible: 1,
        proximo: btnprox,
        anterior: btnant
    });
}

/* Mostra LightBox */
//function showModal(idModal) {
//    $("#" + idModal).dialog({
//        autoOpen: false,
//        modal: true,
//        width: 481,
//        resizable: false,
//        position: 'center',
//        draggable: false,
//        open: function(event, ui) {
//            $(this).parent().removeClass("ui-widget ui-widget-content ui-corner-all ui-resizable");
//            $(this).parent().addClass("Modal");
//            $(this).removeClass("ui-dialog-content ui-widget-content");
//            $(this).siblings(".ui-dialog-titlebar").removeClass("ui-corner-all").find('.ui-icon').addClass("BotaoFechar");
//        }
//    });
//    var dialogBox = $("#" + idModal).dialog('open');
//    dialogBox.parent().appendTo($('#aspnetForm'));
//}

function mostrarAno(ano) {

    $(ano).show();
    $(ano).next().show();

}





$(document).ready(function() {


    $(".NavInstitucional li, .NavMenus li").hover(function() {
        clearTimeout($(this).data('jQueryMenu'));
        $(this).find('ul:first').show();
    }, function() {
        var mm = $(this);
        var timer = setTimeout(function() {
            mm.find('ul:first').hide();
        }, 20);
        $(this).data('jQueryMenu', timer);
    });

    $('.ContainerBusca input.TextBox').each(function() {
        var default_value = this.value;
        $(this).focus(function() {
            if (this.value == default_value) {
                this.value = '';
            }
        });
        $(this).blur(function() {
            if (this.value == '') {
                this.value = default_value;
            }
        });
    });

    slideShow(".DetalhesProduto .ContainerSlide",
    ".DetalhesProduto .SetaProximo",
    ".DetalhesProduto .SetaAnterior");

    slideShow(".ContainerSlideVideo .ContainerSlide",
    ".ContainerSlideVideo .SetaProximo",
    ".ContainerSlideVideo .SetaAnterior");

    $("#tabs").tabs({
        show: function(event, ui) {
            $(this).removeClass("ui-widget ui-corner-all");
            $(this).find("ul:first-child").removeClass("ui-widget-header ui-corner-all");
            $(this).find("li").removeClass("ui-corner-top");
            $(this).find(".ui-state-active").find("a").each(function() {
                $(".ui-state-default a").removeClass("Ativa");
                $(this).addClass("Ativa");
            });
        }
    });

    $('.CabecalhoProdutos').parents('.DestaqueTitulo').addClass('DestaqueTituloProdutos');
    $('.Paginacao .SetaDireita').prev().addClass("Ultimo");
    $('.Paginacao span.Ativo').next('a').hide();
    $('.Paginacao span.Ativo').prev('a').hide();
    $('.ListagemOndeComprar').find('li:last').addClass("Ultimo");

    $('.ConteudoHistoria .Ano').hide();

    mostrarAno('#1994'); //seta primeiros anos exibidos

    $('.LinhaTempo li:first').addClass("Primeira");
    $('.LinhaTempo li:last').addClass("Ultima");
    $('.LinhaTempo li a').click(function() {
        $('.ConteudoHistoria .Ano').hide();
        $('.LinhaTempo li a').removeClass("Ativo");
        $(this).addClass("Ativo");
        mostrarAno($(this).attr('href'));
    });

    $('.ContainerLinhaTempo .BotaoVerTodosAnos').click(function() {
        $('.ConteudoHistoria .Ano').show();
    });


    $('.PerguntasFrequentes li a').click(function() {
        $(this).toggleClass("Ativo");
        $(this).parent("h2").next(".Resposta").slideToggle('slow');
        return (false);
    });

    $('.TextBox').each(function() {
        var default_value = this.value;
        $(this).css('color', '#666');
        $(this).focus(function() {
            if (this.value == default_value) {
                this.value = '';
                $(this).css('color', '#303d40');
            }
        });
        $(this).blur(function() {
            if (this.value == '') {
                $(this).css('color', '#666');
                this.value = default_value;
            }
        });
    });

    //Mapa do Site 

    $('.ListaMapaSite .AreaSite ul').hide();
    $('.ListaMapaSite .RaizSite>span').addClass('Ativo');
    //verifica quais elementos contém submenus e esconde o botão de mais dos que não tem     
    $('.ListaMapaSite li:not(:has(ul))').find(".BotaoExpande").hide();
    $('.ListaMapaSite .BotaoExpande').click(function() {
        $(this).parents('span:first').toggleClass('Ativo');
        $(this).parent().next('ul').toggle(1000);
        return (false);
    });

    //Representantes
    $('.ConteudoRepresentantes .MapaRepresentantes li a').click(function() {

        var estadoClicado = $(this).parent('li');
        $('.ListagemRepresentantes ul').hide();
        $('.ConteudoRepresentantes .ColunaAuxiliar').show();
        $('.ConteudoRepresentantes .ColunaAuxiliar').find('h2 span.Estado').text($(estadoClicado).attr('class'));
        $('.ConteudoRepresentantes .ColunaAuxiliar').find('.' + $(estadoClicado).attr('class')).show();

        return (false);
    });

    /*Função para diminuir e aumentar a fonte*/
    $(".Main p").FontSize({
        MaxSize: 17,
        MinSize: 9,
        SizeUpSelector: '#btnAumentarFonte',
        SizeDownSelector: '#btnDiminuirFonte',
        Increment: 1,
        IgnoreEventTriggers: true,
        ResetSelector: '#btnFontePadrao',
        DefaultSize: 12
    });




});


/////////////////////////////////////////////////////////////////////////////

function showModal(idModal, pxWidth, pxHeight) {
    $("#" + idModal).dialog("destroy");

    $(document).ready(function() {
        $("#" + idModal).dialog({
            autoOpen: false,
            modal: true,
            position: 'center',
            width: pxWidth,
            width: pxHeight,
            draggable: false
        });

        var dialogBox = $("#" + idModal).dialog('open');
        dialogBox.parent().appendTo($('#aspnetForm'));
    });
}

function showModalSemClose(idModal, pxWidth, pxHeight) {
    $("#" + idModal).dialog("destroy");

    $(document).ready(function() {
        $("#" + idModal).dialog({
            autoOpen: false,
            modal: true,
            position: 'center',
            width: pxWidth,
            width: pxHeight,
            draggable: false,
            open: function(event, ui) { $(".ui-dialog-titlebar-close").hide(); }
        });

        var dialogBox = $("#" + idModal).dialog('open');
        dialogBox.parent().appendTo($('#aspnetForm'));
    });
}


function calculaValorPeca(IdValorRevenda, IdValorConsumo, IdTipo, Qtd, IdValorExibicao) {

    var result = "";

    var valorConsumo = $('#' + IdValorConsumo).text();
    var valorRevenda = $('#' + IdValorRevenda).text();
    var qtd = $('#' + Qtd).val();

    valorConsumo = valorConsumo.replace(",", ".");
    valorRevenda = valorRevenda.replace(",", ".");

    if (IdTipo == 'true')
        result = ((valorConsumo) * (qtd));

    else if (IdTipo == 'false')
        result = ((valorRevenda) * (qtd));

    result = (Math.round(result * Math.pow(10, 2)) / Math.pow(10, 2)).toFixed(2);

    result = result.toString().replace(".", ",");

    $('#' + IdValorExibicao).text("R$ " + FormataMoeda(LimpaMoeda(result)));
}


function FormataMoeda(num) {
    x = 0;

    if (num < 0) {
        num = Math.abs(num);
        x = 1;
    }

    if (isNaN(num))
        num = "0";

    cents = Math.floor((num * 100 + 0.5) % 100);
    num = Math.floor((num * 100 + 0.5) / 100).toString();

    if (cents < 10)
        cents = "0" + cents;

    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
        num = num.substring(0, num.length - (4 * i + 3)) + '.' + num.substring(num.length - (4 * i + 3));

    ret = num + ',' + cents;

    if (x == 1)
        ret = ' - ' + ret;

    return ret;
}

function LimpaMoeda(num) {
    num = num.replace(".", "");
    num = num.replace(",", ".");
    return parseFloat(num);
}