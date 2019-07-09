<template>
  <div class="background">
    <mu-appbar style="width: 100%;" title="创建开销" color="#03a9f4"></mu-appbar>
    <mu-flex align-self="center" class="flex-selectstyle">
      <mu-flex justify-content="center" align-self="center" class="name-styleTxt">主分类名称：</mu-flex>
      <mu-flex justify-content="center" align-self="center" class="select-style">
        <mu-select align-self="center" style="width:100%" v-model="mainClassNumber">
          <mu-option
            v-for="opt in listMain"
            :key="opt.numberID"
            :label="opt.valueName"
            :value="opt.numberID"
          ></mu-option>
        </mu-select>
      </mu-flex>
    </mu-flex>
    <mu-flex align-self="center" class="flex-selectstyle">
      <mu-flex justify-content="center" align-self="center" class="name-styleTxt">次分类名称：</mu-flex>
      <mu-flex justify-content="center" align-self="center" class="select-style">
        <mu-select align-self="center" style="width:100%" v-model="subClassNumber">
          <mu-option
            v-for="opt in listSub"
            :key="opt.numberID"
            :label="opt.valueName"
            :value="opt.numberID"
          ></mu-option>
        </mu-select>
      </mu-flex>
    </mu-flex>
    <mu-flex align-self="center" class="flex-selectstyle">
      <mu-flex justify-content="center" align-self="center" class="name-styleTxt">从分类名称：</mu-flex>
      <mu-flex justify-content="center" align-self="center" class="select-style">
        <mu-select align-self="center" style="width:100%" v-model="fromClassNumber">
          <mu-option
            v-for="opt in listFrom"
            :key="opt.numberID"
            :label="opt.valueName"
            :value="opt.numberID"
          ></mu-option>
        </mu-select>
      </mu-flex>
    </mu-flex>
    <mu-flex align-self="center" class="flex-selectstyle">
      <mu-flex justify-content="center" align-self="center" class="name-styleTxt">日期时间：</mu-flex>
      <mu-row gutter class="inputrow-style" style="width:75%">
        <mu-date-input
          v-model="overDate"
          type="dateTime"
          label-float
          full-width
          value-format="yyyy-MM-dd HH:mm"
        ></mu-date-input>
      </mu-row>
      <button class="btn-front-style" @click="FrontDate">前一天</button>
    </mu-flex>
    <mu-flex align-self="center" class="flex-selectstyle">
      <mu-flex justify-content="center" align-self="center" class="name-styleTxt">数值：</mu-flex>
      <mu-row gutter class="inputrow-style">
        <mu-text-field fill="true" v-model="dataNumber" style="width:100%"></mu-text-field>
      </mu-row>
    </mu-flex>
    <mu-flex align-self="center" class="select-selectstyle">
      <mu-flex justify-content="center" align-self="center" class="name-styleTxt">备注：</mu-flex>
      <mu-row gutter class="inputrow-style">
        <mu-text-field fill="true" v-model="Notes" style="width:100%"></mu-text-field>
      </mu-row>
    </mu-flex>
    <mu-flex justify-content="center" inline :key="way.ID" v-for="way in normal">
      <mu-radio :value="way.ID" v-model="DefaultWay" :label="way.Name"></mu-radio>
    </mu-flex>
    <mu-flex align-self="center">
      <button type="button" class="btn-style" @click="ToCreateClass">创建分类</button>
      <button type="button" class="btn-style" @click="AddOverHead">添加</button>
    </mu-flex>
    <mu-flex align-self="center">
      <button
        type="button"
        class="btn-style"
        @click="QueryOverHead"
        style="width:98%;background-color: #9edd55;"
      >查询开销</button>
    </mu-flex>
  </div>
</template>
<script>
export default {
  created() {
    //获取用户信息
    this.$MyIndex.getUserInfo();
    //绑定主分类列表
    this.LoadMainClass();
  },
  data() {
    return {
      overDate: new Date(),
      listMain: [],
      listSub: [],
      listFrom: [],
      mainClassNumber: "",
      subClassNumber: "",
      fromClassNumber: "",
      dataNumber: "",
      Notes: "",
      normal: [
        { ID: 1, Name: "WX" },
        { ID: 2, Name: "Alipay" },
        { ID: 3, Name: "Other" }
      ],
      DefaultWay: 1
    };
  },
  methods: {
    //加载主分类
    LoadMainClass() {
      this.$api.post("Class/QueryMainClass", null, r => {
        r.data.map(val => {
          val.state = val.state == 1 ? "使用中" : "停用";
        });
        this.listMain = r.data;
        if (this.listMain.length == 0) {
          this.mainClassNumber = "";
        } else {
          this.mainClassNumber = this.listMain[0].numberID;
        }
      });
    },
    //加载次分类table
    LoadSubClass() {
      if (this.mainClassNumber == "") return;
      var para = { ParentID: this.mainClassNumber };
      this.$api.post("Class/QuerySubClass", para, r => {
        r.data.map(val => {
          val.state = val.state == 1 ? "使用中" : "停用";
        });
        this.listSub = r.data;
        if (this.listSub.length == 0) {
          this.subClassNumber = "";
        } else {
          this.subClassNumber = this.listSub[0].numberID;
        }
      });
    },
    //加载从分类table
    LoadFromClass() {
      if (this.subClassNumber == "") return;
      var para = { ParentID: this.subClassNumber };
      this.$api.post("Class/QueryFromClass", para, r => {
        r.data.map(val => {
          val.state = val.state == 1 ? "使用中" : "停用";
        });
        this.listFrom = r.data;
        if (this.listFrom.length == 0) {
          this.fromClassNumber = "";
        } else {
          this.fromClassNumber = this.listFrom[0].numberID;
        }
      });
    },
    //添加开销
    AddOverHead() {
      var para = {
        userID: "001",
        mainClassID: this.mainClassNumber,
        subClassID: this.subClassNumber,
        fromClassID: this.fromClassNumber,
        dataNumber: this.dataNumber,
        useTime: this.overDate,
        note: this.Notes
      };
      this.$api.post(
        "OverHead/AddOverHead",
        para,
        r => {
          // this.LoadMainClass();
          // this.overDate = "";
          // this.dataNumber = "";
          // this.Notes = "";
          this.$Msg.TipAlert(r.msg);
        },
        m => {
          this.$Msg.TipAlert(m);
        }
      );
    },
    //前往创建分类页
    ToCreateClass() {
      this.$router.push({ path: "/CreateClass?use=" + this.$MyIndex.MyToken });
    },
    //前往查询开销页
    QueryOverHead() {
      this.$router.push({
        path: "/QueryOverHead?use=" + this.$MyIndex.MyToken
      });
    },
    //加载前一天
    FrontDate() {
      // this.overDate
      var para = { CurrentDate: this.overDate };
      this.$api.post(
        "User/GetFrontDate",
        para,
        r => {
          if (r.data != "" && r.data != "undefined") {
            // this.$Msg.TipAlert(r.data);
            this.overDate = r.data + "";
            //this.overDate = "2019-07-05 09:00";
          }
        },
        m => {
          this.$Msg.TipAlert(m);
        }
      );
    }
  },
  watch: {
    mainClassNumber(number, oldNumber) {
      this.mainClassNumber = number;
      //绑定次分类列表   主分类变更时更新次分类
      this.LoadSubClass();
    },
    subClassNumber(number, oldNumber) {
      this.subClassNumber = number;
      //绑定次分类列表   次分类变更时更新从分类
      this.LoadFromClass();
    }
  }
};
</script>

