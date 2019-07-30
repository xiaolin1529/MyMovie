
    /* 鼠标特效 */
    var a_idx = 0;
    jQuery(document).ready(function ($) {
        $("body").click(function (e) {
            var a = [
                "斗地主", "吃火锅", "打豆豆", "饮酒", "吃肉",
                "狼人杀", "泡妹子", "耍流氓", "耍无赖", "身体将康",
                "家人幸福", "找女朋友", "生猴子","蒸羊羔儿","蒸熊掌","蒸鹿尾儿","烧花鸭"
                ,"烧雏鸡","烧子鹅","炉猪","炉鸭","酱鸡","腊肉","松花","小肚儿","晾肉","香肠儿","什锦苏盘儿"
                ,"熏鸡白肚儿"
            ];
            var b = [
                "#FFF68F", "#FFBBFF", "#FF0000", "#FF00FF", "#F08080",
                "#008000", "#7FFFAA", "#0000CD", "#0000FF", "#080808"
            ];
            var a_index = Math.floor((Math.random() * a.length));
            var b_index = Math.floor((Math.random() * b.length));

            var color = b[b_index];
            var $i = $("<span/>").text(a[a_index]);
            /* a_idx = (a_idx + 1) % a.length; */
            var x = e.pageX,
                y = e.pageY;

            $i.css({
                "z-index": 999999999999999999999999999999999999999999999999999999999999999999999,
                "top": y - 20,
                "left": x,
                "position": "absolute",
                "font-weight": "bold",
                "color": color,
            });
            $("body").append($i);
            $i.animate({
                "top": y - 180,
                "opacity": 0
            }, 1500, function () {
                $i.remove();
            });
        });
    });
