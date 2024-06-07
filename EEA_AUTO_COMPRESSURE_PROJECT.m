 clear all;


cd 'C:\Users\ICG\OneDrive\바탕 화면\motor_test\Motor_test_1\data\state_data_buffer\4mm\dry_collagen\normal'

%% parameter

dry_collagen_data_num = 50;
wet_collagen_data_num = 99;
total_collagen_data_num = dry_collagen_data_num + wet_collagen_data_num;
cut_off = 0.4; % (strain - value max = 0.80// pressure = //gapdistance = )
j = 1;
data_load = 0; % 0 = make data / 1 = load data
data_category = ["strain_table", "pressure_table", "gapdistance_table"];


%% read data and make datatable
if data_load == 0

for i = 1:dry_collagen_data_num
  myfilename(i) = "AI_state_data" + i + ".csv";
end



for i = 1:dry_collagen_data_num
    dataBuffer = readmatrix(myfilename(i));
    pressure_table = dataBuffer(:,3);
    strain_table = dataBuffer(:,8);
    thickness_table = dataBuffer(:,11);
    gapdistance_table = dataBuffer(:,7);
    data_table = [pressure_table, strain_table, thickness_table, gapdistance_table];
    A = min(find(strain_table));
    B = size(strain_table);

    data_table = data_table(A:B(1),1:4);

    %   n 이하에서의 분류
    % k = data_table(:,2) < cut_off;
    % n = min(find(k == 0)) - 1;
    % 
    % data_table = data_table(1:n,1:4);
    % pressure_table = data_table(:,1);
    % strain_table = data_table(:,2);
    % thickness_table = data_table(:,3);
    % gapdistance_table = data_table(:,4);

    % figure(i)
    % plot(strain_table, pressure_table)
    % 전부
    % data_table = data_table(A:B(1),1:4);
    % pressure_table = data_table(:,1);
    % strain_table = data_table(:,2);
    % thickness_table = data_table(:,3);
    % gapdistance_table = data_table(:,4);

    data_table = rmmissing(data_table);   

    
    curve_fit = fit(data_table(:,2),data_table(:,1),'exp1');

    A = coeffvalues(curve_fit);
    a(i) = A(:,1);
    b(i) = A(:,2);
    c(i) = max(pressure_table);
    d(i) = thickness_table(1);
    e(i) = min(gapdistance_table);

    max_strain(i) = max(strain_table);
end



cd 'C:\Users\ICG\OneDrive\바탕 화면\motor_test\Motor_test_1\data\state_data_buffer\4mm\wet_collagen\normal'

for i = 1:wet_collagen_data_num 
    dataBuffer = readmatrix(myfilename(i));
    pressure_table = dataBuffer(:,3);
    strain_table = dataBuffer(:,8);
    thickness_table = dataBuffer(:,11); 
    gapdistance_table = dataBuffer(:,7);
    data_table = [pressure_table, strain_table, thickness_table, gapdistance_table];   
    A = min(find(strain_table));
    B = size(strain_table);

    data_table = data_table(A:B(1),1:4);

    %   n 이하에서의 분류
    k = data_table(:,2) < cut_off;
    n = min(find(k == 0)) - 1;

    data_table = data_table(1:n,1:4);
    pressure_table = data_table(:,1);
    strain_table = data_table(:,2);
    thickness_table = data_table(:,3);
    gapdistance_table = data_table(:,4);

    % figure(i + 50)
    % plot(strain_table, pressure_table)
    % 전부
    % data_table = data_table(A:B(1),1:4);
    % pressure_table = data_table(:,1);
    % strain_table = data_table(:,2);
    % thickness_table = data_table(:,3);
    % gapdistance_table = data_table(:,4);

    data_table = rmmissing(data_table);


    
    curve_fit = fit(data_table(:,2),data_table(:,1),'exp1');

    A = coeffvalues(curve_fit);
    a(dry_collagen_data_num + i) = A(:,1);
    b(dry_collagen_data_num + i) = A(:,2);
    c(dry_collagen_data_num + i) = max(pressure_table);
    d(dry_collagen_data_num + i) = thickness_table(1);
    e(dry_collagen_data_num + i) = min(gapdistance_table);

    max_strain(dry_collagen_data_num + i) = max(strain_table);
end



for i = 1:total_collagen_data_num
    Number(i) = i;
end

for i = 1:total_collagen_data_num
    if(i > dry_collagen_data_num)
      state(i) = "wet";
    else
      state(i) = "dry";
    end
end

for i =1:total_collagen_data_num
    Model_a(i) = a(i);
    Model_b(i) = b(i);
    maximum_pressure(i) = c(i);
    thickness(i) = d(i);
    gapdistance(i) = e(i);
end

Number = transpose(Number);
state = transpose(state);
Model_a = transpose(Model_a);
Model_b = transpose(Model_b);
maximum_pressure = transpose(maximum_pressure);
thickness = transpose(thickness);
max_strain = transpose(max_strain);
gapdistance = transpose(gapdistance);


for i = 1:total_collagen_data_num
    thickness_pressure(i) = thickness(i)/maximum_pressure(i);
    max_strain(i) =  max_strain(i);
end
thickness_pressure = transpose(thickness_pressure);
max_strain_for_nolimit = (thickness - 50) ./ (thickness)
SVM_collagen_table = table(Number, state, Model_a,Model_b,maximum_pressure , thickness, thickness_pressure, max_strain, gapdistance, max_strain_for_nolimit);
SVM_collagen_table2 = table(Number, Model_a,Model_b,maximum_pressure , thickness, thickness_pressure, max_strain, gapdistance);

end


%% 훈련데이터 읽기(예측해야하는 값)

cd 'C:\Users\ICG\OneDrive\바탕 화면\motor_test\Motor_test_1\data\data storage'
total_maximum_pressure = readmatrix("total_maximum_pressure");
total_maximum_pressure_no_limit = readmatrix("total_maximum_pressure_no_limit");
total_Model_b = readmatrix("total_Model_b");
total_Model_a = readmatrix("total_Model_a");
total_damage_deep = readmatrix("total_damage_deep_table.csv");
total_damage_deep_class = readmatrix("total_damage_deep_table_class.csv");
total_wet_damage_deep = readmatrix("wet_damage_deep_table.csv");
total_wet_damage_deep_class = readmatrix("total_wet_damage_deep_table_class.csv");

%% 상태 분류
trainingData = SVM_collagen_table;
addpath 'C:\Users\ICG\OneDrive\바탕 화면\motor_test\Motor_test_1\data\train_model'

[trainedClassifier, validationAccuracy] = trainClassifier_state(trainingData);
[state_predict,scores] = trainedClassifier.predictFcn(trainingData);%여기는 원래 입려되는 데이터 값을 해야하는데 지금은 일단 훈련데이터와 동일하게함

predict_table = table(Number, state_predict, Model_a,Model_b,maximum_pressure , thickness, thickness_pressure, max_strain, gapdistance, max_strain_for_nolimit);
%% predict total maximum pressure

trainingData = predict_table;
responseData = total_maximum_pressure;


[trainedMode, validationRMSE] = trainRegressionModel_maximumpressure(trainingData, responseData)

predict_total_maximum_pressure = trainedMode.predictFcn(trainingData)%%여기서 trainData가 아니라 실제 대상인 값이 와서 예측이 되어져야한다. 임시로 훈련데이터를 넣음


predict_table = table(Number, state_predict, Model_a,Model_b,maximum_pressure, predict_total_maximum_pressure, thickness, thickness_pressure, max_strain, gapdistance,max_strain_for_nolimit);


%% curvefitting(use predict total maximum pressure)

for i = 1:total_collagen_data_num 
    if(i > dry_collagen_data_num)
        cd 'C:\Users\ICG\OneDrive\바탕 화면\motor_test\Motor_test_1\data\state_data_buffer\4mm\wet_collagen\normal'                    
    else
        cd 'C:\Users\ICG\OneDrive\바탕 화면\motor_test\Motor_test_1\data\state_data_buffer\4mm\dry_collagen\normal'         
    end

    if(j > dry_collagen_data_num)
        j = 1;
    end


    dataBuffer = readmatrix(myfilename(j));
    pressure_table = dataBuffer(:,3);
    strain_table = dataBuffer(:,8);
    data_table2 = [pressure_table, strain_table];   
    A = min(find(strain_table));
    B = size(strain_table);

%   n 이하에서의 분류
    k = strain_table < cut_off;
    n = min(find(k == 0)) - 1;


    data_table2 = data_table2(A:n,1:2);
    data_table2(n-A+2,1) = predict_total_maximum_pressure(i);
    data_table2(n-A+2,2) = 0.8;

    curve_fit = fit(data_table2(:,2),data_table2(:,1),'exp1');

    A = coeffvalues(curve_fit);
    Model_a(i) = A(:,1);
    Model_b(i) = A(:,2);

    j = j + 1;
end

predict_table = table(Number, state_predict, Model_a,Model_b,maximum_pressure, predict_total_maximum_pressure, thickness, thickness_pressure, max_strain, gapdistance, max_strain_for_nolimit);
%% predict Model_a
trainingData = predict_table;
responseData = total_Model_a;


[trainedMode, validationRMSE] = trainRegressionModel_Model_a(trainingData, responseData);

predict_Model_a = trainedMode.predictFcn(trainingData)%%여기서 trainData가 아니라 실제 대상인 값이 와서 예측이 되어져야한다. 임시로 훈련데이터를 넣음

predict_table = table(Number, state_predict, Model_a, predict_Model_a,Model_b,maximum_pressure, predict_total_maximum_pressure, thickness, thickness_pressure, max_strain, gapdistance, max_strain_for_nolimit);

%% predict Model_b
trainingData = predict_table;
responseData = total_Model_b;


[trainedMode, validationRMSE] = trainRegressionModel_Model_b(trainingData, responseData);


predict_Model_b = trainedMode.predictFcn(trainingData)%%여기서 trainData가 아니라 실제 대상인 값이 와서 예측이 되어져야한다. 임시로 훈련데이터를 넣음




%% 예측한 maximumpressure을 가지고 측징 추출
for i = 1:total_collagen_data_num
    predict_thickness_pressure(i) = thickness(i)/predict_total_maximum_pressure(i);
end
predict_thickness_pressure = transpose(predict_thickness_pressure);

predict_table = table(Number, state_predict, Model_a, predict_Model_a,Model_b,predict_Model_b,maximum_pressure, predict_total_maximum_pressure, thickness, thickness_pressure, predict_thickness_pressure, max_strain, gapdistance, max_strain_for_nolimit);


%% 위에서 얻은 exp 계수를 통해 특징 추출
x = 30:5:80;
exp_Model = (predict_Model_a) .*exp(predict_Model_b .* (x * 0.01));

for i = 1:length(x) - 1
    exp_Model_delta(:,i) = exp_Model(:,(i + 1)) - exp_Model(:,i);
end

table_buffer = table((exp_Model(:,1)), (exp_Model(:,2)), (exp_Model(:,3)), (exp_Model(:,4)), (exp_Model(:,5)), (exp_Model(:,6)), (exp_Model(:,7)), (exp_Model(:,8)), (exp_Model(:,9)), (exp_Model(:,10)), (exp_Model(:,11)) ...
    ,'VariableNames',["exp_30", "exp_35", "exp_40", "exp_45", "exp_50", "exp_55", "exp_60", "exp_65", "exp_70", "exp_75", "exp_80"]);
predict_table = [predict_table table_buffer];
table_buffer = table((exp_Model_delta(:,1)), (exp_Model_delta(:,2)), (exp_Model_delta(:,3)), (exp_Model_delta(:,4)), (exp_Model_delta(:,5)), (exp_Model_delta(:,6)), (exp_Model_delta(:,7)), (exp_Model_delta(:,8)), (exp_Model_delta(:,9)), (exp_Model_delta(:,10)) ...
    ,'VariableNames',["delta35to30", "delta40to35", "delta45to40", "delta50to45", "delta55to50", "delta60to55", "delta65to60", "delta70to65", "delta75to70", "delta80to75"]);
predict_table = [predict_table table_buffer];


%% 모델링을 미분시에 해당 기울기일 떄 변형률 값

 slop_1 = log(1 ./ (predict_Model_a .* predict_Model_b)) ./ predict_Model_b;
 slop_10 = log(10 ./ (predict_Model_a .* predict_Model_b)) ./ predict_Model_b;
 slop_100 = log(100 ./ (predict_Model_a .* predict_Model_b)) ./ predict_Model_b;

table_buffer = table(slop_1,slop_10,slop_100,'VariableNames',["slop_1", "slop_10", "slop_100"]);
predict_table = [predict_table table_buffer];

%% maximum pressure no limit

trainingData = predict_table;
responseData = total_maximum_pressure_no_limit;


[trainedMode, validationRMSE] = trainRegressionModel_maximumpressure(trainingData, responseData)

predict_total_maximum_pressure_gap = trainedMode.predictFcn(trainingData)

table_buffer = table(predict_total_maximum_pressure_gap,'VariableNames',["predict_total_maximum_pressure_gap"]);
predict_table = [predict_table table_buffer];


%% dry, wet 분류

row_safe = find(total_damage_deep_class == 1)
row_dangerous = find(total_damage_deep_class == 2)
row_emergency = find(total_damage_deep_class == 3)

total_damage_deep_class_char(row_safe,:) = "1_safe"
total_damage_deep_class_char(row_dangerous,:) = "2_intermediate"
total_damage_deep_class_char(row_emergency,:) = "2_intermediate"

% total_damage_deep_class_char(row_safe,:) = "1_safe"
% total_damage_deep_class_char(row_dangerous,:) = "3_dangerous"
% total_damage_deep_class_char(row_emergency,:) = "3_dangerous"

rows = (state_predict == "dry")
state_dry = predict_table(rows,:)
state_dry_target_damage_deep = total_damage_deep(rows,:);
state_dry_class_char = total_damage_deep_class_char(rows,:);



rows = (state_predict == "wet")
%%
state_wet = predict_table(rows,:)
state_wet_target_damage_deep = total_damage_deep(rows,:);
state_wet_class_char = total_damage_deep_class_char(rows,:)

%% predict set deep damage _ wet

trainingData = state_wet;
responseData = state_wet_target_damage_deep;

[trainedMode, validationRMSE] = trainRegressionModel_wet_deep_damage(trainingData, responseData);


predict_damage_deep_wet = trainedMode.predictFcn(trainingData)%%여기서 trainData가 아니라 실제 대상인 값이 와서 예측이 되어져야한다. 임시로 훈련데이터를 넣음
predict_damage_deep_wet = table(predict_damage_deep_wet, 'VariableNames', ["predict_wet_damage"]);
state_wet = [state_wet predict_damage_deep_wet];

%% predict set deep damage _ dry

trainingData = state_dry;
responseData = state_dry_target_damage_deep;

[trainedMode, validationRMSE] = trainRegressionModel_dry_deep_damage(trainingData, responseData);


predict_damage_deep_dry = trainedMode.predictFcn(trainingData)%%여기서 trainData가 아니라 실제 대상인 값이 와서 예측이 되어져야한다. 임시로 훈련데이터를 넣음
predict_damage_deep_dry = table(predict_damage_deep_dry, 'VariableNames', ["predict_dry_damage"]);
state_dry = [state_dry predict_damage_deep_dry];




%%
% trainingData = state_wet;
% responseData = state_wet_class_char;
% responseData = cellstr(responseData)
% 
% [trainedClassifier, validationAccuracy] = trainClassifier_state_final_wet_state(trainingData, responseData);
% [state_predict_final,scores] = trainedClassifier.predictFcn(trainingData);%여기는 원래 입려되는 데이터 값을 해야하는데 지금은 일단 훈련데이터와 동일하게함
% 

%%
% dry_class = table(state_dry_class_char)
% state_dry_oversampling = [state_dry dry_class]
% state_dry_oversampling.state_predict = [];
% state_dry_oversampling.Number = [];
% 
% data_dry = state_dry_oversampling;  % 데이터를 테이블로 읽어옴
% minorityLabel = '2_intermediate';  % 오버샘플링할 소수 클래스 레이블
% num2Add = 44;  % 생성할 데이터 개수
% % options.NumNeighbors = 5;  % 이웃 데이터 개수
% % options.Standardize = 'false';  % 표준화 옵션 설정
% 
% % method: myADASYN, mySafeLevelSMOTE, myBorderlineSMOTE, mySMOTE
% [newdata_dry, visdata] = mySafeLevelSMOTE(data_dry, minorityLabel, num2Add);
% 
% state_dry_oversampling = cat(1, data_dry, newdata_dry);
% 
% %%
% wet_class = table(state_wet_class_char)
% state_wet_oversampling = [state_wet wet_class]
% state_wet_oversampling.state_predict = [];
% state_wet_oversampling.Number = [];
% 
% data_wet = state_wet_oversampling;  % 데이터를 테이블로 읽어옴
% minorityLabel = '1_safe';  % 오버샘플링할 소수 클래스 레이블
% num2Add = 17;  % 생성할 데이터 개수
% % options.NumNeighbors = 5;  % 이웃 데이터 개수
% % options.Standardize = 'false';  % 표준화 옵션 설정
% % 
% % % method: myADASYN, mySafeLevelSMOTE, myBorderlineSMOTE, mySMOTE
% [newdata_wet, visdata] = mySafeLevelSMOTE(data_wet, minorityLabel, num2Add);
% 
% state_wet_oversampling = cat(1, data_wet, newdata_wet);