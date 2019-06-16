import "muse-ui-message/dist/muse-ui-message.css";
import Vue from "vue";
import Message from "muse-ui-message";
Vue.use(Message);

// 返回在vue模板中的调用接口
export default {
    TipAlert: function (text) {
        Message.alert(text, "提示");
    }
}