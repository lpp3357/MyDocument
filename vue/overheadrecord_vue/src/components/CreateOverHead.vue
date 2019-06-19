<template>
  <div class="background">
    <mu-appbar style="width: 100%;" title="创建开销" color="#03a9f4"></mu-appbar>
    <mu-flex align-self="center">
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
    <mu-flex align-self="center">
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
    <mu-flex align-self="center">
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
    <mu-flex align-self="center">
      <mu-flex justify-content="center" align-self="center" class="name-styleTxt">日期与时间：</mu-flex>
      <mu-row gutter class="select-style">
        <mu-col span="12" lg="4" sm="6">
          <mu-date-input v-model="value11" type="dateTime" label-float full-width landscape></mu-date-input>
        </mu-col>
      </mu-row>
    </mu-flex>
  </div>
</template>
<script>
export default {
  created() {
    //绑定主分类列表
    this.LoadMainClass();
  },
  data() {
    return {
      value11: "",
      listMain: [],
      listSub: [],
      listFrom: [],
      mainClassNumber: "",
      subClassNumber: "",
      fromClassNumber: ""
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

