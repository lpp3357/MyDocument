const MyToken = "123";



export default {
    created() {
        console.log(111);
    },
    data() {
        // return {
        //     MyToken: ""
        // }
    },
    MyToken,
    //获取url参数
    getUrlKey: function (name) {
        return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(location.href) || [, ""])[1].replace(/\+/g, '%20')) || null
    },
    getUserInfo: function () {
        var name = 'use';
        var info = decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(location.href) || [, ""])[1].replace(/\+/g, '%20')) || null;
        //if (info != null && info != "") {
        this.MyToken = info;
        //}
    },
    watch: {
        MyToken(newv, oldv) {
            console.log("变化了");
        }
    }
}