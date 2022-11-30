<?php 
	include_once("db.php");

	
	function getUserData($username, $password){
		GLOBAL $con;

		$sql = "SELECT shelf_type, books_id FROM Shelf JOIN User ON User.to_read_shelf = Shelf.shelf_id WHERE username=? AND password=? 
		UNION SELECT shelf_type, books_id FROM Shelf JOIN User ON User.reading_shelf = Shelf.shelf_id WHERE username=? AND password=? 
		UNION SELECT shelf_type, books_id FROM Shelf JOIN User ON User.read_shelf = Shelf.shelf_id WHERE username=? AND password=?
		UNION SELECT shelf_type, books_id FROM Shelf JOIN User ON User.favorite_shelf = Shelf.shelf_id WHERE username=? AND password=?
		UNION SELECT shelf_type, books_id FROM Shelf JOIN User ON User.recommendation_shelf = Shelf.shelf_id WHERE username=? AND password=?";
		$st = $con->prepare($sql);

		$st->execute(array($username, sha1($password), $username, sha1($password), $username, sha1($password), $username, sha1($password), $username, sha1($password)));
		$all = $st->fetchAll();

		if(count($all) > 0){
			for($shelf = 0; $shelf < count($all); $shelf++){
				// if(strcmp($all[$shelf]["shelf_type"],"to_read") == 0){
				// 	echo $all[$shelf]["books_id"].",";
				// } else if(strcmp($all[$shelf]["shelf_type"],"reading") == 0){
				// 	echo $all[$shelf]["books_id"].",";
				// } else if(strcmp($all[$shelf]["shelf_type"],"read") == 0){
				// 	echo $all[$shelf]["books_id"].",";
				// } else if(strcmp($all[$shelf]["shelf_type"],"favorite") == 0){
				// 	echo $all[$shelf]["books_id"].",";
				// } else {
				// 	echo $all[$shelf]["books_id"];
				// }
				if($shelf == count($all)-1){
					echo $all[$shelf]["books_id"];	
				} else{
					echo $all[$shelf]["books_id"].",";
				}
			}
		}
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


	if (isset($_POST["username"]) && !empty($_POST["username"]) && 
		isset($_POST["password"]) && !empty($_POST["password"])){

		getUserData($_POST["username"], $_POST["password"]);
	}

	// getUserData("johndoe", "johndoe");

	

	//if username or password is null (not set)
	// echo "SERVER: Logged in";

	//exit():  means end server connection (don't execute the rest)
?>