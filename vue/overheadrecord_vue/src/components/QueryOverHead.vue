<template>
  <div class="background" id="aoo">
    <mu-appbar style="width: 100%;" title="查询开销" color="#03a9f4">
      <mu-button icon slot="left" @click="backClick()">
        <mu-icon value="<" color:red></mu-icon>
      </mu-button>
    </mu-appbar>
    <!-- 查询头 -->
    <mu-flex align-self="center">
      <mu-select class="qo-select-style" v-model="CurrentYear" style="margin-left:2.5%">
        <mu-option v-for="o in listYear" :key="o.ID" :label="o.Value" :value="o.ID"></mu-option>
      </mu-select>
      <mu-select class="qo-select-style" v-model="CurrentMonth">
        <mu-option v-for="o in listMonth" :key="o.ID" :label="o.Value" :value="o.ID"></mu-option>
      </mu-select>
      <mu-select class="qo-select-style" v-model="CurrentDay">
        <mu-option v-for="o in listDay" :key="o.ID" :label="o.Value" :value="o.ID"></mu-option>
      </mu-select>
      <button type="button" class="qo-btn-style" @click="QueryOverHeadRecord(0)">查询</button>
      <button
        type="button"
        class="qo-btn-style"
        style="margin-left:0.01%; background-color: #9edd55;"
        @click="QueryOverHeadRecord(1)"
      >本月</button>
      <button
        type="button"
        class="qo-btn-style"
        style="margin-left:0.01%; background-color: #9edd55;"
        @click="QueryOverHeadRecord(2)"
      >本年</button>
    </mu-flex>
    <mu-flex align-self="center" style="height:35px">
      <mu-flex align-self="center" class="name-styleTxt">{{OutTotal}}</mu-flex>
      <mu-flex align-self="center" class="name-styleTxt">收入总量：0</mu-flex>
    </mu-flex>
    <!-- 数据tabl -->
    <mu-flex>
      <mu-data-table :columns="columns" :data="Overlist" :rowStyle="setStyle" class="cc-table">
        <template slot-scope="scope">
          <td style="text-align: center;padding:0">{{scope.row.mainValueName}}</td>
          <td style="text-align: center;padding:0">{{scope.row.subValueName}}</td>
          <td style="text-align: center;padding:0">{{scope.row.fromValueName}}</td>
          <td style="text-align: center;padding:0">{{scope.row.dataNumber}}</td>
          <td style="text-align: center;padding:0">{{scope.row.useTimeStr}}</td>
          <td style="text-align: center;padding:0">{{scope.row.note}}</td>
        </template>
      </mu-data-table>
    </mu-flex>
  </div>
</template>
<script>
export default {
  created() {
    //获取用户信息
    this.$MyIndex.getUserInfo();
    //加载年份
    for (let index = 2019; index < 2019 + 5; index++) {
      this.listYear.push({ ID: index, Value: index + "年" });
    }
    this.CurrentYear = new Date().getFullYear(); //当前年份
    //加载月份
    for (let index = 1; index < 13; index++) {
      this.listMonth.push({ ID: index, Value: index + "月" });
    }
    this.GetQueryMonthDay(true);
  },
  data() {
    return {
      listYear: [], //年下拉列表
      CurrentYear: 1, //选中年
      listMonth: [{ ID: 0, Value: "月份" }], //月下拉列表
      CurrentMonth: 1, //选中月
      listDay: [{ ID: 0, Value: "天数" }], //天下拉列表
      CurrentDay: 1, //选中天
      columns: [
        // 定义table表头
        { title: "主分类", width: 50 },
        { title: "次分类", width: 65 },
        { title: "从分类", width: 65 },
        { title: "数量", width: 65 },
        { title: "日期", width: 80 },
        { title: "备注" }
      ],
      Overlist: [],
      OutTotal: "支出总量：0",
      listMain: [{ numberID: 1, valueName: "111" }],
      mainClassNumber: ""
    };
  },
  methods: {
    //设置行样式
    setStyle(rowIndex, row) {
      return "height: 35px;font-size: 1.05em;padding:0";
    },
    //前往首页
    backClick() {
      this.$router.push({ path: "/?use=" + this.$MyIndex.MyToken });
    },
    //加载查询年月日
    GetQueryMonthDay(isMonth) {
      if (this.CurrentYear == "") return;
      var para = { Year: this.CurrentYear, Month: this.CurrentMonth };
      this.$api.post("General/GetQueryDate", para, r => {
        if (r.data.length == 0) return;
        var month = r.data[0].split(":")[1]; //当前月
        if (isMonth) this.CurrentMonth = parseInt(month);
        var TotalDays = r.data[1].split(":")[1]; //当前月总天数
        var total = parseInt(TotalDays) + 1;
        this.listDay = [];
        this.listDay.push({ ID: 0, Value: "天数" });
        for (let index = 1; index < total; index++) {
          this.listDay.push({ ID: index, Value: index + "" });
        }
        let day = r.data[2].split(":")[1]; //当前天
        this.CurrentDay = parseInt(day);
      });
    },
    //查询开销记录
    QueryOverHeadRecord(ismonth) {
      var curDay = this.CurrentDay;
      var curMonth = this.CurrentMonth;
      if (ismonth == 1) curDay = "";
      if (ismonth == 2) {
        curDay = "";
        curMonth = "";
      }
      var para = {
        Year: this.CurrentYear,
        Month: curMonth,
        Day: curDay
      };
      this.$api.post("OverHead/QueryOverHead", para, r => {
        this.Overlist = r.data;
        var total = 0;
        r.data.map(val => {
          total += parseInt(val.dataNumber);
        });
        this.OutTotal = "支出总量：" + total;
      });
    }
  },
  watch: {
    CurrentYear(number, oldNumber) {
      this.CurrentYear = number;
      //绑定月份 年份变更时更新月份
      this.GetQueryMonthDay(false);
    },
    CurrentMonth(number, oldNumber) {
      this.CurrentMonth = number;
      //绑定天数 月份变更时更新天数
      this.GetQueryMonthDay(false);
    }
  }
};
</script>

