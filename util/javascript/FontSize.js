//***********************************************************************
//	OBJETIVO			: Disponibilizar funcionalidades de Aumentar e 
//						  Fontes de textos			
//-----------------------------------------------------------------------
//	AUTOR				: Cristiano Souza Silva
//	Data CRIAO		: 29/5/2009 
//	MANUTENO			:
//	OBSERVAO			:
//
//************************************************************************

//Extende o objeto jQuery
(function(jQuery) {
    //Define o nome do plugin
    jQuery.fn.FontSize = function(options) {
        //Define as configuracoes padrao ao instanciar o objeto
        var options = jQuery.extend({}, jQuery.fn.FontSize.defaults, options);
        defaultSize = (options.DefaultSize != "undefined") ? options.DefaultSize : jQuery(Container).css('font-size');
        //Recupera o objeto onde sera executado a altercao na fonte
        Container = jQuery(this);

        //Adiciona o evento ao objeto que ir aumentar a fonte
        jQuery(options.SizeUpSelector).click(function() {
            //Recupera o tamanho atual
            Size = parseInt(jQuery(Container).css('font-size').split(options.Unit)[0]);
            //tamanho mximo ainda no tiver sido atingido
            if (Size < options.MaxSize) {
                //Altera a fonte com o incremento fornecido
                Size = (Size + options.Increment > options.MaxSize) ? options.MaxSize : Size + options.Increment;
                jQuery(Container).css('font-size', Size + "" + options.Unit);
            }
            return false;
        });

        //Adiciona o evento ao objeto que ir diminuir a fonte
        jQuery(options.SizeDownSelector).click(function() {
            //Recupera o tamanho atual
            Size = parseInt(jQuery(Container).css('font-size').split(options.Unit)[0]);
            if (Size > options.MinSize) {
                Size = (Size - options.Increment < options.MinSize) ? options.MinSize : Size - options.Decrement;
                jQuery(Container).css('font-size', Size + "" + options.Unit);
            }
            return false;
        });

        jQuery(options.ResetSelector).click(function() {
            //Recupera o tamanho atual
            Size = defaultSize;
            jQuery(Container).css('font-size', Size + "" + options.Unit);
            return false;
        });

    }

    //	Configuracoes Padro do plugin

    jQuery.fn.FontSize.defaults = {
        MinSize: 7, //Tamanho m�nimo dos textos
        MaxSize: 14, //Tamanho m�ximo dos textos
        SizeUpSelector: "#SizeUp", //Seletor do objeto que ir ativar o evento "Aumentar fonte" ex para link com o id SizeUp
        SizeDownSelector: "#SizeDown", //Seletor do objeto que ir ativar o evento "Aumentar fonte" ex para link com o id SizeDown
        ResetSelector: "#ResetSize",
        Increment: 1, //Incremento do tamanho dos textos de acordo com a unidade fornecida (padro aumentar 1px por clique)
        Decrement: 1, //Decremento do tamanho dos textos de acordo com a unidade fornecida  (padro diminuir 1px por clique)
        Unit: "px" //Unidade a ser usada no incremento e nas comparaes (padro px "Pixels")

    };

})(jQuery);
 
		   
