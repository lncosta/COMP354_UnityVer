<?php 
	include_once("db.php");

	
	function getUserData($username, $password){
		GLOBAL $con;

		$sql = "SELECT userData FROM User WHERE username=? AND password=?";
		$st = $con->prepare($sql);

		$st->execute(array($username, sha1($password)));
		$all = $st->fetchAll();

		if(count($all) > 0){
			echo $all[0]["userData"];
		}
		exit();
	}

	function pushUserData($data, $username, $password){
		GLOBAL $con;

		$sql = "UPDATE User SET userData=? WHERE username=? AND password=?";
		$st = $con->prepare($sql);

		try{
			$st->execute(array($data, $username, sha1($password)));
		} catch(PDOException $e){
			echo $sql."<br>".$e->getMessage();
		}
		exit();
	}

	function Login($username, $password){
		GLOBAL $con;

		$sql = "SELECT username FROM User WHERE username=? AND password=?";
		$st=$con->prepare($sql);

		$st->execute(array($username, sha1($password)));//encrypt password
		$all=$st->fetchAll();
		if (count($all) == 1){
			echo "SERVER: ID#".$all[0]["username"];
			exit();
		}

		//if username or password are empty strings
		echo "SERVER: Login successful!";
		exit();
	}


	if(isset($_POST["data"]) && !empty($_POST["data"]) && isset($_POST["username"]) && !empty($_POST["username"]) && 
	isset($_POST["password"]) && !empty($_POST["password"])){
		
		pushUserData($_POST["data"], $_POST["username"], $_POST["password"]);
	} else if (isset($_POST["username"]) && !empty($_POST["username"]) && 
		isset($_POST["password"]) && !empty($_POST["password"])){

		getUserData($_POST["username"], $_POST["password"]);
	}

	// getUserData("johndoe", "johndoe");

	

	//if username or password is null (not set)
	// echo "SERVER: Logged in";

	//exit():  means end server connection (don't execute the rest)
?>