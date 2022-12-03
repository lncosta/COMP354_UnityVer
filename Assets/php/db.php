<?php
	header("Access-Control-Allow-Origin: *");
    $host   = "mysql:dbname=book_project;host=localhost:3306";
	$user   = "root";
	$pass   = "";
	$option = array(PDO::MYSQL_ATTR_INIT_COMMAND => "SET NAMES utf8");
	try{
		$con = new PDO($host,$user, $pass, $option);
		$con->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
	}catch(PDOException $e){ echo $e; }
?>